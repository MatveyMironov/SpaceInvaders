using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyGrid
{
    [SerializeField] private Dictionary<Vector2Int, Enemy> enemies = new Dictionary<Vector2Int, Enemy>();
    [SerializeField] private int columnsCount;
    [SerializeField] private int rowsCount;

    public Dictionary<Vector2Int, Enemy> Enemies { get { return enemies; } }
    public int ColumnsCount { get { return columnsCount; } }
    public int RowsCount { get { return rowsCount; } }
}
