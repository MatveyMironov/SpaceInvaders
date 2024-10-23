using System;
using UnityEngine;

[Serializable]
public class EnemyGrid
{
    [SerializeField] private Column[] columns = new Column[0];

    public EnemyGrid(Column[] columns)
    {
        this.columns = columns;
    }

    public Column[] Columns { get => columns; }

    [Serializable]
    public class Column
    {
        [SerializeField] private Enemy[] enemies = new Enemy[0];

        public Column(Enemy[] enemies)
        {
            this.enemies = enemies;
        }

        public Enemy[] Enemies { get => enemies; }
    }
}
