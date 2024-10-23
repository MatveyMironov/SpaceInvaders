using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerShooting playerShooting;

    public bool IsInputEnabled { get; set; } = true;

    public void InvokeMovement(float moveInput)
    {
        if (!IsInputEnabled) { return; }

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

    public void InvokeShoot()
    {
        if (!IsInputEnabled) { return; }

        playerShooting.Shoot();
    }
}
