using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMovement movement;

    public EnemyMovement Movement { get { return movement; } }

    private void Update()
    {
        movement.MovementTick();
    }
}
