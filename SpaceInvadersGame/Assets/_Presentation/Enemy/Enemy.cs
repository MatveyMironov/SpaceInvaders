using UnityEngine;

public class Enemy : MonoBehaviour, IDestroyable
{
    private Movement _movement = new();

    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private MovementField movementField;

    private Vector2 _movementDirection = Vector2.left;

    private void Update()
    {
        _movement.MoveObject(transform, _movementDirection, movementSpeed, movementField);

        Debug.Log(transform.position);
        if (movementField.CheckIfOnTheEdge(transform.position))
        {
            Debug.Log("1");
            _movementDirection.x = -_movementDirection.x;
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
