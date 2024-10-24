using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IHitable
{
    [SerializeField] private Transform muzzle;
    [SerializeField] private EnemyMovement movement;

    public EnemyMovement Movement { get { return movement; } }

    public Transform Muzzle { get => muzzle; }

    public event Action OnEnemyDestoyed;

    private void Update()
    {
        movement.MovementTick();
    }

    public void Hit()
    {
        OnEnemyDestoyed?.Invoke();
        Destroy(gameObject);
    }

}
