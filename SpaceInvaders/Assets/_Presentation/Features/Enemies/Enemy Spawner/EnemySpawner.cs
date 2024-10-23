using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private SpawnerProgram spawnerProgram;
    [SerializeField] private Transform spawnOrigin;

    [ContextMenu("Spawn Enemies")]
    public EnemyPack SpawnEnemies()
    {
        EnemyGrid.Column[] columns = new EnemyGrid.Column[spawnerProgram.EnemyGrid.Columns.Length];

        for (int i = 0; i < spawnerProgram.EnemyGrid.Columns.Length; i++)
        {
            Enemy[] enemies = new Enemy[spawnerProgram.EnemyGrid.Columns[i].Enemies.Length];

            for (int j = 0; j < spawnerProgram.EnemyGrid.Columns[i].Enemies.Length; j++)
            {
                Enemy enemyPrefab = spawnerProgram.EnemyGrid.Columns[i].Enemies[j];

                Vector3 spawnPoint = new Vector3();
                spawnPoint.x = spawnOrigin.position.x - (float)i * spawnerProgram.HorizontalDistance;
                spawnPoint.y = spawnOrigin.position.y - (float)j * spawnerProgram.VerticalDistance;
                
                Enemy enemy = Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
                enemies[j] = enemy;
            }

            columns[i] = new EnemyGrid.Column(enemies);
        }

        return new EnemyPack(new EnemyGrid(columns), spawnerProgram.HorizontalDistance, spawnerProgram.VerticalDistance);
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
