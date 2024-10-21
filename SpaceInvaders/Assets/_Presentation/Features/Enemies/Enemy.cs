using UnityEngine;

public class Enemy : MonoBehaviour, IHitable
{
    [SerializeField] private EnemyMovement movement;

    public EnemyMovement Movement { get { return movement; } }

    private void Update()
    {
        movement.MovementTick();
    }

    public void Hit()
    {
        Destroy(gameObject);
    }

}
