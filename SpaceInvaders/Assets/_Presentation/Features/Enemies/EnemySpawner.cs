using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private List<Vector2Int> gridPositions = new();
    [SerializeField] private Transform UpperRightCorner;
    [SerializeField] private float horizontalDistance;
    [SerializeField] private float verticalDistance;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        foreach (var gridPosition in gridPositions)
        {
            Vector3 worldPosition = new Vector3(UpperRightCorner.position.x - (gridPosition.x * horizontalDistance), 
                UpperRightCorner.position.y - (gridPosition.y * verticalDistance), 0);

            Gizmos.DrawSphere(worldPosition, 0.5f);
        }
    }
}
