using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerShooting playerShooting;

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

    public void InvokeShoot()
    {
        playerShooting.Shoot();
    }
}
