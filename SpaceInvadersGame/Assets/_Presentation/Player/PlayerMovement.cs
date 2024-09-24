using UnityEngine;

public class PlayerMovement
{
    public void MovePlayer(Transform player, float horizontalDirection, float speed)
    {
        player.position += new Vector3(horizontalDirection * speed * Time.deltaTime, 0f, 0f);
    }
}
