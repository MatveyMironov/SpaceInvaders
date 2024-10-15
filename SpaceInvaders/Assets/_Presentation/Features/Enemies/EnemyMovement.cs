using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class EnemyMovement
{
    [SerializeField] private Transform enemyTransform;
    [SerializeField] private float movementSpeed;

    private Vector3 _targetPosition;
    private bool _needsToMove;

    public bool HasReachedTarget { get { return enemyTransform.position == _targetPosition; } }

    public void MovementTick()
    {
        if (_needsToMove && !HasReachedTarget)
        {
            enemyTransform.position = Vector3.MoveTowards(enemyTransform.position, _targetPosition, movementSpeed * Time.deltaTime);
        }
    }

    public void SetMovementTarget(Vector2 position2D)
    {
        _targetPosition = position2D;
        _needsToMove = true;
    }
}
