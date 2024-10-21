using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    [Space]
    [SerializeField] private MovementField playerMovementField;

    private Vector3 _movementDirection;

    private void Update()
    {
        if (_movementDirection != Vector3.zero)
        {
            Vector3 nextPosition = transform.position + _movementDirection * movementSpeed * Time.deltaTime;
            Vector3 clarifiedPosition = playerMovementField.ClampPositionToField(nextPosition);
            transform.position = clarifiedPosition;
        }
    }

    public void ChangeMovementDirection(Vector2 newDirection)
    {
        _movementDirection = newDirection;
    }
}
