using UnityEngine;

public class Enemy : MonoBehaviour, IHitable
{
    [SerializeField] private Transform muzzle;
    [SerializeField] private EnemyMovement movement;

    public EnemyMovement Movement { get { return movement; } }

    public Transform Muzzle { get => muzzle; }

    private void Update()
    {
        movement.MovementTick();
    }

    public void Hit()
    {
        Destroy(gameObject);
    }

}
