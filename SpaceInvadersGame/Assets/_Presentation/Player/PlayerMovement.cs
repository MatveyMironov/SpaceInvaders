using UnityEngine;

public class PlayerMovement
{
    public void MovePlayer(Transform player, int horizontalDirection, float speed, MovementField movementField)
    {
        Vector3 newPosition = player.position + new Vector3(horizontalDirection * speed * Time.deltaTime, 0f, 0f);
        player.position = movementField.ClampPositionToField(newPosition);
    }
}
