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

    private PlayerMovement _playerMovement = new();
    private Gun _playerGun = new();

    private float _movementDirection = 0;

    private void Update()
    {
        _playerGun.FunctioningTick(rechargingTime);

        if (_movementDirection != 0)
        {
            _playerMovement.MovePlayer(transform, Mathf.RoundToInt(_movementDirection), movementSpeed, movementField);
        }
    }

    private void SetNewMovementDirection(float direction)
    {
        _movementDirection = direction;
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
