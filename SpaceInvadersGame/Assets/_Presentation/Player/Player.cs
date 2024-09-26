using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private MovementField movementField;

    [Header("Shooting")]
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private float rechargingTime;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private Transform muzzle;

    private Movement _playerMovement = new();
    private Gun _playerGun = new();

    private Vector2 _movementDirection = Vector2.zero;

    private void Update()
    {
        _playerGun.FunctioningTick(rechargingTime);

        if (_movementDirection != Vector2.zero)
        {
            _playerMovement.MoveObject(transform, _movementDirection, movementSpeed, movementField);
        }
    }

    private void SetNewMovementDirection(float direction)
    {
        _movementDirection.x = direction;
    }

    private void Shoot()
    {
        _playerGun.Shoot(projectilePrefab, muzzle, projectileSpeed, movementField);
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
