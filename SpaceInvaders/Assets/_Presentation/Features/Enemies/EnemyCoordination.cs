using System.Collections.Generic;
using UnityEngine;

public class EnemyCoordination : MonoBehaviour
{
    [SerializeField] private MovementField movementField;
    [SerializeField] private EnemySpawner spawner;

    private EnemyRectangularPack _enemyPack;

    private float _currentHeight = 0;

    private MovementDirection _previousDirection;
    private MovementDirection _currentDirection;

    private enum MovementDirection
    {
        down,
        left,
        right,
    }

    private void Start()
    {
        List<Enemy> enemies = spawner.SpawnEnemies();
        _enemyPack = new EnemyRectangularPack(enemies);

        Vector3 movingLeft = new Vector3(movementField.LeftBorder - _enemyPack.Leftest, 0, 0);
        StartMovingTo(movingLeft);
        _previousDirection = MovementDirection.left;
        _currentDirection = MovementDirection.left;
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

            Vector3 movementTarget = Vector3.zero;

            if (_currentDirection == MovementDirection.left)
            {
                _currentHeight--;
                movementTarget = new Vector3(movementField.LeftBorder - _enemyPack.Leftest, _currentHeight, 0);
                ChangeMovementDirection(MovementDirection.down);
            }
            else if (_currentDirection == MovementDirection.right)
            {
                _currentHeight--;
                movementTarget = new Vector3(movementField.RightBorder - _enemyPack.Rightest, _currentHeight, 0);
                ChangeMovementDirection(MovementDirection.down);
            }
            else if (_currentDirection == MovementDirection.down)
            {
                if (_previousDirection == MovementDirection.left)
                {
                    movementTarget = new Vector3(movementField.RightBorder - _enemyPack.Rightest, _currentHeight, 0);
                    ChangeMovementDirection(MovementDirection.right);
                }
                else if (_previousDirection == MovementDirection.right)
                {
                    movementTarget = new Vector3(movementField.LeftBorder - _enemyPack.Leftest, _currentHeight, 0);
                    ChangeMovementDirection(MovementDirection.left);
                }
            }

            StartMovingTo(movementTarget);
        }
    }

    private void ChangeMovementDirection(MovementDirection direction)
    {

        _previousDirection = _currentDirection;
        _currentDirection = direction;
    }

    private void StartMovingTo(Vector3 position)
    {
        foreach (var enemyPlace in _enemyPack.EnemyPlaces)
        {
            if (enemyPlace != null)
            {
                Vector3 movementTarget = enemyPlace.RelativePosition + position;

                enemyPlace.Enemy.Movement.SetMovementTarget(movementTarget);
            }
        }
    }

    private bool CheckIfAllReachedPosition()
    {
        bool allHaveReached = true;

        foreach (var enemyPlace in _enemyPack.EnemyPlaces)
        {
            allHaveReached &= enemyPlace.Enemy.Movement.HasReachedTarget;
        }

        return allHaveReached;
    }

    private bool CheckIfAnyReachedLowerBorder()
    {
        return _enemyPack.GetLowest() <= movementField.LowerBorder;
    }
}
