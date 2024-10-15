using UnityEngine;

public class MovementField : MonoBehaviour
{
    [SerializeField] private Transform upperLeftCorner;
    [SerializeField] private Transform lowerRightCorner;

    public float UpperBorder { get { return upperLeftCorner.position.y; } }
    public float LowerBorder { get { return lowerRightCorner.position.y; } }
    public float LeftBorder { get { return upperLeftCorner.position.x; } }
    public float RightBorder { get { return lowerRightCorner.position.x; } }

    public bool IsPositionInsideField(Vector3 position)
    {
        return (
            position.y < UpperBorder 
            && position.y > LowerBorder
            && position.x > LeftBorder
            && position.x < RightBorder);
    }
}
