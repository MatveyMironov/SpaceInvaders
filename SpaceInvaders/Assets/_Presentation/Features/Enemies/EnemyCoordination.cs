using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCoordination : MonoBehaviour
{
    [SerializeField] private MovementField movementField;
    [SerializeField] private EnemySpawner spawner;

    [Header("Combat")]
    [SerializeField] private EnemyShooter shooter;
    [SerializeField] private float salvoCooldown;
    [SerializeField, Range(1, 10)] private int maxSalvoMembers;

    private EnemyPack _enemyPack;

    private float _currentHeight;

    private MovementDirection _previousDirection;
    private MovementDirection _currentDirection;

    Vector3 _movementTarget = Vector3.zero;

    private enum MovementDirection
    {
        down,
        left,
        right,
    }

    private void Start()
    {
        _enemyPack = spawner.SpawnEnemies();

        _currentHeight = _enemyPack.EnemyGrid.Columns[0].Enemies[0].transform.position.y;

        _movementTarget = new Vector3(movementField.LeftBorder + _enemyPack.Width, _currentHeight, 0);
        StartMovingTo(_movementTarget);
        _previousDirection = MovementDirection.left;
        _currentDirection = MovementDirection.left;

        StartCoroutine(ShootingCouroutine());
    }

    private void Update()
    {
        if (CheckIfAllReachedPosition())
        {
            if (CheckIfAnyReachedLowerBorder())
            {
                Debug.Log("Reached Lower Border");
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
    }

    private void ChangeMovementDirection(MovementDirection direction)
    {

        _previousDirection = _currentDirection;
        _currentDirection = direction;
    }

    private void StartMovingTo(Vector3 position)
    {
        for (int i = 0; i < _enemyPack.EnemyGrid.Columns.Length; i++)
        {
            for (int j = 0; j < _enemyPack.EnemyGrid.Columns[i].Enemies.Length; j++)
            {
                if (_enemyPack.EnemyGrid.Columns[i].Enemies[j] != null)
                {
                    Vector3 movementTarget = position;
                    movementTarget.x -= i * _enemyPack.HorizontalDistance;
                    movementTarget.y -= j * _enemyPack.VerticalDistance;

                    _enemyPack.EnemyGrid.Columns[i].Enemies[j].Movement.SetMovementTarget(movementTarget);
                }
            }
        }
    }

    private bool CheckIfAllReachedPosition()
    {
        bool allHaveReached = true;

        foreach (var column in _enemyPack.EnemyGrid.Columns)
        {
            foreach (var enemy in column.Enemies)
            {
                if (enemy != null)
                {
                    allHaveReached &= enemy.Movement.CheckIfHasReachedTarget();
                }
            }
        }

        return allHaveReached;
    }

    private bool CheckIfAnyReachedLowerBorder()
    {
        return _enemyPack.GetLowestHeight() <= movementField.LowerBorder;
    }

    private IEnumerator ShootingCouroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(salvoCooldown);

            List<Enemy> salvoCandidates = _enemyPack.GetAllLowest();
            List<Enemy> salvoMembers = new();

            for (int i = 0; i < maxSalvoMembers; i++)
            {
                if (salvoCandidates.Count <= 0) { break; }

                int index = Random.Range(0, salvoCandidates.Count - 1);
                salvoMembers.Add(salvoCandidates[index]);
                salvoCandidates.RemoveAt(index);
            }

            foreach (var salvoMember in salvoMembers)
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
