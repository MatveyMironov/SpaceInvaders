using UnityEngine;

public class MovementField : MonoBehaviour
{
    [SerializeField] private Transform upperLeftCorner;
    [SerializeField] private Transform lowerRightCorner;

    public bool CheckIfPositionIsOnField(Vector3 position)
    {
        if (position.x > upperLeftCorner.position.x
            && position.x < lowerRightCorner.position.x
            && position.y < upperLeftCorner.position.y
            && position.y > lowerRightCorner.position.y
            )
        {
            return true;
        }

        return false;
    }
}
