using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private SpawnerProgram spawnerProgram;
    [SerializeField] private Transform spawnOrigin;

    [ContextMenu("Spawn Enemies")]
    public EnemyPack SpawnEnemies()
    {
        List<List<EnemyPack.EnemyPlace>> enemies = new();

        for (int i = 0; i < spawnerProgram.EnemyGrid.Columns.Length; i++)
        {
            List<EnemyPack.EnemyPlace> column = new();

            for (int j = 0; j < spawnerProgram.EnemyGrid.Columns[i].Enemies.Length; j++)
            {
                Enemy enemyPrefab = spawnerProgram.EnemyGrid.Columns[i].Enemies[j];

                Vector3 relativePosition = Vector3.zero;
                relativePosition.x = -(float)i * spawnerProgram.HorizontalDistance;
                relativePosition.y = -(float)j * spawnerProgram.VerticalDistance;

                Vector3 spawnPoint = new Vector3();
                spawnPoint.x = spawnOrigin.position.x + relativePosition.x;
                spawnPoint.y = spawnOrigin.position.y + relativePosition.y;

                Enemy enemy = Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
                EnemyPack.EnemyPlace enemyPlace = new(enemy, relativePosition);
                column.Add(enemyPlace);
            }

            enemies.Add(column);
        }

        return new EnemyPack(enemies, spawnerProgram.HorizontalDistance, spawnerProgram.VerticalDistance);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1.0f, 0, 0, 0.5f);

        for (int i = 0; i < spawnerProgram.EnemyGrid.Columns.Length; i++)
        {
            for (int j = 0; j < spawnerProgram.EnemyGrid.Columns[i].Enemies.Length; j++)
            {
                Vector3 spawnPoint = new Vector3();
                spawnPoint.x = spawnOrigin.position.x - (float)i * spawnerProgram.HorizontalDistance;
                spawnPoint.y = spawnOrigin.position.y - (float)j * spawnerProgram.VerticalDistance;

                Gizmos.DrawSphere(spawnPoint, 0.5f);
            }
        }
    }
}
