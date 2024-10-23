using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyPack
{
    public EnemyPack(EnemyGrid enemyGrid, float horizontalDistance, float verticalDistance)
    {
        EnemyGrid = enemyGrid;

        HorizontalDistance = horizontalDistance;
        VerticalDistance = verticalDistance;

        Width = CalculateWidth();
        Height = CalculateHeight();
    }

    public EnemyGrid EnemyGrid { get; }

    public float HorizontalDistance { get; }
    public float VerticalDistance { get; }

    public float Width { get; }
    public float Height { get; }

    public float GetLowestHeight()
    {
        float lowestHeight = float.MaxValue;

        foreach (var column in EnemyGrid.Columns)
        {
            foreach (var enemy in column.Enemies)
            {
                if (enemy != null)
                {
                    if (enemy.transform.position.y < lowestHeight)
                    {
                        lowestHeight = enemy.transform.position.y;
                    }
                }
            }
        }

        return lowestHeight;
    }

    public List<Enemy> GetAllLowest()
    {
        List<Enemy> enemies = new();

        foreach (var column in EnemyGrid.Columns)
        {
            for (int i = column.Enemies.Length - 1; i >= 0; i--)
            {
                Enemy enemy = column.Enemies[i];

                if (enemy != null)
                {
                    enemies.Add(enemy);

                    break;
                }
            }
        }

        return enemies;
    }

    private float CalculateWidth()
    {
        return (EnemyGrid.Columns.Length - 1) * HorizontalDistance;
    }

    private float CalculateHeight()
    {
        int maxRowsCount = 0;

        foreach (var column in EnemyGrid.Columns)
        {
            if (column.Enemies.Length > maxRowsCount)
            {
                maxRowsCount = column.Enemies.Length;
            }
        }

        return maxRowsCount * VerticalDistance;
    }
}
