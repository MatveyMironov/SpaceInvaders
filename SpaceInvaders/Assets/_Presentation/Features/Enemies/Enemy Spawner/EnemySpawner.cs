using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints = new();

    [Space]
    [SerializeField] private Enemy enemyPrefab;

    [ContextMenu("Spawn Enemies")]
    public List<Enemy> SpawnEnemies()
    {
        List<Enemy> spawnedEnemies = new();

        foreach (var spawnPoint in spawnPoints)
        {
            Enemy enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            spawnedEnemies.Add(enemy);
        }

        return spawnedEnemies;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1.0f, 0, 0, 0.5f);

        foreach (var spawnPoint in spawnPoints)
        {
            Gizmos.DrawSphere(spawnPoint.position, 0.5f);
        }
    }
}
