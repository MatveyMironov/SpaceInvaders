using System.Collections.Generic;
using UnityEngine;

public class EnemyPack
{
    public EnemyPack(List<List<EnemyPlace>> enemies, float horizontalDistance, float verticalDistance)
    {
        Enemies = enemies;

        HorizontalDistance = horizontalDistance;
        VerticalDistance = verticalDistance;

        Width = CalculateWidth();
        Height = CalculateHeight();

        Subscribe();
    }

    public List<List<EnemyPlace>> Enemies { get; }

    public float HorizontalDistance { get; }
    public float VerticalDistance { get; }

    public float Width { get; }
    public float Height { get; }

    public float GetLowestHeight()
    {
        float lowestHeight = float.MaxValue;

        foreach (var column in Enemies)
        {
            foreach (var enemy in column)
            {
                if (enemy != null)
                {
                    if (enemy.Enemy.transform.position.y < lowestHeight)
                    {
                        lowestHeight = enemy.Enemy.transform.position.y;
                    }
                }
            }
        }

        return lowestHeight;
    }

    public List<Enemy> GetAllLowest()
    {
        List<Enemy> lowestEnemies = new();

        foreach (var column in Enemies)
        {
            if (column.Count > 0)
            {
                Enemy lowestEnemy = column[column.Count - 1].Enemy;
                lowestEnemies.Add(lowestEnemy);
            }
        }

        return lowestEnemies;
    }

    private void Subscribe()
    {
        foreach (var column in Enemies)
        {
            foreach (var enemy in column)
            {
                enemy.Enemy.OnEnemyDestoyed += () => { column.Remove(enemy); };
            }
        }
    }

    private float CalculateWidth()
    {
        return (Enemies.Count - 1) * HorizontalDistance;
    }

    private float CalculateHeight()
    {
        int maxRowsCount = 0;

        foreach (var column in Enemies)
        {
            if (column.Count > maxRowsCount)
            {
                maxRowsCount = column.Count;
            }
        }

        return (maxRowsCount - 1) * VerticalDistance;
    }

    public class EnemyPlace
    {
        public EnemyPlace(Enemy enemy, Vector3 relativePosition)
        {
            Enemy = enemy;
            RelativePosition = relativePosition;
        }

        public Enemy Enemy { get; }
        public Vector3 RelativePosition { get; }
    }
}
