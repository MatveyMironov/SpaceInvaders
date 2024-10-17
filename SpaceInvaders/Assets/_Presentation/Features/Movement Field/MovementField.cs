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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Vector3 center = new Vector3((RightBorder + LeftBorder) / 2, (UpperBorder + LowerBorder) / 2, 0);
        Vector3 size = new Vector3(RightBorder - LeftBorder, UpperBorder - LowerBorder, 0);
        Gizmos.DrawWireCube(center, size);
    }
}