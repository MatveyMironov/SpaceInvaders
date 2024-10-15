using System.Collections.Generic;
using UnityEngine;

public class EnemyRectangularPack
{
    private List<EnemyPlace> _enemiePlaces;

    public EnemyRectangularPack(List<Enemy> enemies)
    {
        _enemiePlaces = new();

        foreach (Enemy enemy in enemies)
        {
            EnemyPlace enemyPlace = new(enemy, enemy.transform.position);
            _enemiePlaces.Add(enemyPlace);
        }

        Uppest = GetUppest();
        Lowest = GetLowest();
        Rightest = GetRightest();
        Leftest = GetLeftest();
    }

    public List<EnemyPlace> EnemyPlaces { get { return _enemiePlaces; } }

    public float Uppest { get; private set; }
    public float Lowest { get; private set; }
    public float Rightest { get; private set; }
    public float Leftest { get; private set; }

    public float GetUppest()
    {
        float uppest = float.MinValue;

        foreach (var enemyPlace in _enemiePlaces)
        {
            if (enemyPlace.Enemy.transform.position.y > uppest)
            {
                uppest = enemyPlace.Enemy.transform.position.y;
            }
        }

        return uppest;
    }

    public float GetLowest()
    {
        float lowest = float.MaxValue;

        foreach (var enemyPlace in _enemiePlaces)
        {
            if (enemyPlace.Enemy.transform.position.y < lowest)
            {
                lowest = enemyPlace.Enemy.transform.position.y;
            }
        }

        return lowest;
    }

    public float GetRightest()
    {
        float rightest = float.MinValue;

        foreach (var enemyPlace in _enemiePlaces)
        {
            if (enemyPlace.Enemy.transform.position.x > rightest)
            {
                rightest = enemyPlace.Enemy.transform.position.x;
            }
        }

        return rightest;
    }

    public float GetLeftest()
    {
        float leftest = float.MaxValue;

        foreach (var enemyPlace in _enemiePlaces)
        {
            if (enemyPlace.Enemy.transform.position.x < leftest)
            {
                leftest = enemyPlace.Enemy.transform.position.x;
            }
        }

        return leftest;
    }

    public class EnemyPlace
    {
        private Enemy _enemy;
        private Vector3 _relativePosition;

        public EnemyPlace(Enemy enemy, Vector3 relativePosition)
        {
            _enemy = enemy;
            _relativePosition = relativePosition;
        }

        public Enemy Enemy { get { return _enemy; } }
        public Vector3 RelativePosition { get { return _relativePosition; } }
    }
}
