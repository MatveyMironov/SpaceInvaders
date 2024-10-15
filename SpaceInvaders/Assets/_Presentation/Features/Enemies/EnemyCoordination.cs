using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCoordination : MonoBehaviour
{
    [SerializeField] private EnemyGrid enemyGrid;
    [SerializeField] private MovementField movementField;

    private void Start()
    {
        StartMoving();
    }

    private void Update()
    {
        
    }

    private void StartMoving()
    {
        for (int i = 0; i < enemyGrid.RowsCount; i++)
        {
            for (int j = 0; j < enemyGrid.ColumnsCount; j++)
            {
                Vector2Int gridPosition = new Vector2Int(j, i);
                if (enemyGrid.Enemies.ContainsKey(gridPosition))
                {
                    Enemy enemy = enemyGrid.Enemies[gridPosition];
                    if (enemy != null)
                    {
                        Vector2 movementTarget = new Vector2(movementField.LeftBorder + j, enemy.transform.position.y);
                        enemy.Movement.SetMovementTarget(movementTarget);
                    }
                }
            }
        }
    }
}
