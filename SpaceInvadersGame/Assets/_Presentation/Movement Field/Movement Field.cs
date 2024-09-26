using UnityEngine;

public class MovementField : MonoBehaviour
{
    [SerializeField] private Transform upperLeftCorner;
    [SerializeField] private Transform lowerRightCorner;

    public Vector3 ClampPositionToField(Vector3 position)
    {
        Vector3 clampedPosition = position;

        if (position.x < upperLeftCorner.position.x)
        {
            clampedPosition.x = upperLeftCorner.position.x;
        }

        if (position.x > lowerRightCorner.position.x)
        {
            clampedPosition.x = lowerRightCorner.position.x;
        }

        if (position.y > upperLeftCorner.position.y)
        {
            clampedPosition.y = upperLeftCorner.position.y;
        }

        if (position.y < lowerRightCorner.position.y)
        {
            clampedPosition.y= lowerRightCorner.position.y;
        }

        return clampedPosition;
    }
}
