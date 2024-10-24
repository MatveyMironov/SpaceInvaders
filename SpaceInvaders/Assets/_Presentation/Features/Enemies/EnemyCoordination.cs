using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyCoordination : MonoBehaviour
{
    [SerializeField] private MovementField movementField;
    [SerializeField] private EnemySpawner spawner;

    [Header("Combat")]
    [SerializeField] private EnemyShooter shooter;
    [SerializeField] private float salvoCooldown;
    [SerializeField, Range(1, 10)] private int maxSalvoMembers;

    private float _salvoTimer = 0f;

    private EnemyPack _enemyPack;

    private float _currentHeight;

    private MovementDirection _previousDirection;
    private MovementDirection _currentDirection;

    private Vector3 _movementTarget = Vector3.zero;

    public event Action OnLowerBorderReached;
    public event Action OnAllEnemiesDestroyed;

    private enum MovementDirection
    {
        down,
        left,
        right,
    }

    private void Update()
    {
        if (_enemyPack == null) { return; }

        if (CheckIfAllReachedPosition())
        {
            if (CheckIfAnyReachedLowerBorder())
            {
                OnLowerBorderReached?.Invoke();
                return;
            }

            if (_currentDirection == MovementDirection.left)
            {
                _currentHeight--;
                _movementTarget = new Vector3(movementField.LeftBorder + _enemyPack.Width, _currentHeight, 0);
                ChangeMovementDirection(MovementDirection.down);
            }
            else if (_currentDirection == MovementDirection.right)
            {
                _currentHeight--;
                _movementTarget = new Vector3(movementField.RightBorder, _currentHeight, 0);
                ChangeMovementDirection(MovementDirection.down);
            }
            else if (_currentDirection == MovementDirection.down)
            {
                if (_previousDirection == MovementDirection.left)
                {
                    _movementTarget = new Vector3(movementField.RightBorder, _currentHeight, 0);
                    ChangeMovementDirection(MovementDirection.right);
                }
                else if (_previousDirection == MovementDirection.right)
                {
                    _movementTarget = new Vector3(movementField.LeftBorder + _enemyPack.Width, _currentHeight, 0);
                    ChangeMovementDirection(MovementDirection.left);
                }
            }

            StartMovingTo(_movementTarget);
        }

        if (CheckIfAllDestoryed())
        {
            OnAllEnemiesDestroyed?.Invoke();
        }

        _salvoTimer += Time.deltaTime;
        if (_salvoTimer >= salvoCooldown)
        {
            Shoot();
            _salvoTimer = 0;
        }
    }

    public void StartEnemies()
    {
        _enemyPack = spawner.SpawnEnemies();

        _currentHeight = _enemyPack.Enemies[0][0].Enemy.transform.position.y;

        _movementTarget = new Vector3(movementField.LeftBorder + _enemyPack.Width, _currentHeight, 0);
        StartMovingTo(_movementTarget);
        _previousDirection = MovementDirection.left;
        _currentDirection = MovementDirection.left;
    }

    public void DestroyAllEnemies()
    {
        if (_enemyPack == null) { return; }

        foreach (var column in _enemyPack.Enemies)
        {
            foreach (var enemy in column)
            {
                Destroy(enemy.Enemy.gameObject);
            }
        }

        _enemyPack = null;
    }

    private void ChangeMovementDirection(MovementDirection direction)
    {

        _previousDirection = _currentDirection;
        _currentDirection = direction;
    }

    private void StartMovingTo(Vector3 position)
    {
        for (int i = 0; i < _enemyPack.Enemies.Count; i++)
        {
            for (int j = 0; j < _enemyPack.Enemies[i].Count; j++)
            {
                EnemyPack.EnemyPlace enemyPlace = _enemyPack.Enemies[i][j];

                if (enemyPlace != null)
                {
                    Vector3 movementTarget = position;
                    movementTarget.x += enemyPlace.RelativePosition.x;
                    movementTarget.y += enemyPlace.RelativePosition.y;

                    enemyPlace.Enemy.Movement.SetMovementTarget(movementTarget);
                }
            }
        }
    }

    private bool CheckIfAllReachedPosition()
    {
        bool allHaveReached = true;

        foreach (var column in _enemyPack.Enemies)
        {
            foreach (var enemy in column)
            {
                if (enemy != null)
                {
                    allHaveReached &= enemy.Enemy.Movement.CheckIfHasReachedTarget();
                }
            }
        }

        return allHaveReached;
    }

    private bool CheckIfAllDestoryed()
    {
        foreach (var column in _enemyPack.Enemies)
        {
            if (column.Count > 0)
            {
                return false;
            }
        }

        return true;
    }

    private bool CheckIfAnyReachedLowerBorder()
    {
        return _enemyPack.GetLowestHeight() <= movementField.LowerBorder;
    }

    private void Shoot()
    {
        List<Enemy> salvoCandidates = _enemyPack.GetAllLowest();
        List<Enemy> salvoMembers = new();

        for (int i = 0; i < maxSalvoMembers; i++)
        {
            if (salvoCandidates.Count <= 0) { break; }

            int index = UnityEngine.Random.Range(0, salvoCandidates.Count - 1);
            salvoMembers.Add(salvoCandidates[index]);
            salvoCandidates.RemoveAt(index);
        }

        foreach (var salvoMember in salvoMembers)
        {
            if (salvoMember != null)
            {
                shooter.Shoot(salvoMember.Muzzle);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0f, 0, 1.0f, 0.5f);

        Gizmos.DrawSphere(_movementTarget, 0.5f);
    }
}
