using UnityEngine;

public class MovementField : MonoBehaviour
{
    [SerializeField] private Transform upperLeftCorner;
    [SerializeField] private Transform lowerRightCorner;

    public bool CheckIfInsideField(Vector3 position)
    {
        if (position.x >= upperLeftCorner.position.x
            && position.x <= lowerRightCorner.position.x
            && position.y <= upperLeftCorner.position.y
            && position.y >= lowerRightCorner.position.y)
        {
            return true;
        }

        return false;
    }

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
