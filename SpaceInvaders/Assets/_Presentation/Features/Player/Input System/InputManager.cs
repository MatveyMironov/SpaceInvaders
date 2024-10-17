using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;

    public void InvokeMovement(float moveInput)
    {
        Vector2 direction = Vector2.zero;

        if (moveInput > 0)
        {
            direction = Vector2.right;
        }
        else if (moveInput < 0)
        {
            direction = Vector2.left;
        }

        playerMovement.ChangeMovementDirection(direction);
    }
}
