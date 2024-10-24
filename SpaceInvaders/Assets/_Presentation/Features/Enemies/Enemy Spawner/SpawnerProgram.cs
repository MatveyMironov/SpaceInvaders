using UnityEngine;

[CreateAssetMenu(fileName = "NewSpawnerProgram", menuName = "Spawner Program")]
public class SpawnerProgram : ScriptableObject
{
    [SerializeField] private EnemyGrid enemyGrid;

    [SerializeField] private float horizontalDistance;
    [SerializeField] private float verticalDistance;

    public EnemyGrid EnemyGrid { get => enemyGrid; }

    public float HorizontalDistance { get => horizontalDistance; }
    public float VerticalDistance { get => verticalDistance; }
}
