using UnityEngine;

public class Movement
{
    public void MoveObject(Transform objectBeingMoved, Vector2 movementDirection, float speed, MovementField movementField)
    {
        Vector2 motion = movementDirection.normalized * speed * Time.deltaTime;
        Vector3 newPosition = objectBeingMoved.position + new Vector3(motion.x, motion.y, 0f);
        objectBeingMoved.position = movementField.ClampPositionToField(newPosition);
    }
}
