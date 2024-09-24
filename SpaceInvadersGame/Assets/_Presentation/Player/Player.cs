using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private PlayerMovement _playerMovement = new();

    private float _movementDirection = 0;

    private void Update()
    {
        if (_movementDirection != 0)
        {
            _playerMovement.MovePlayer(transform, _movementDirection, movementSpeed);
        }
    }

    private void SetNewMovementDirection(float direction)
    {
        _movementDirection = direction;
    }

    private void OnEnable()
    {
        InputListener.OnMovementCalled += SetNewMovementDirection;
    }
}
