using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    [Header("Shooting")]
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private Transform muzzle;

    private PlayerMovement _playerMovement = new();
    private Gun _playerShooting = new();

    private float _movementDirection = 0;

    private void Update()
    {
        if (_movementDirection != 0)
        {
            _playerMovement.MovePlayer(transform, Mathf.RoundToInt(_movementDirection), movementSpeed);
        }
    }

    private void SetNewMovementDirection(float direction)
    {
        _movementDirection = direction;
    }

    private void Shoot()
    {
        _playerShooting.Shoot(projectilePrefab, muzzle, projectileSpeed);
    }

    private void OnEnable()
    {
        InputListener.OnMovementCalled += SetNewMovementDirection;
        InputListener.OnShootCalled += Shoot;
    }

    private void OnDisable()
    {
        InputListener.OnMovementCalled -= SetNewMovementDirection;
        InputListener.OnShootCalled -= Shoot;
    }
}
