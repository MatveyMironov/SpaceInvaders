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

    public Vector3 ClampPositionToField(Vector3 position)
    {
        if (position.y > UpperBorder)
        {
            position.y = UpperBorder;
        }
        else if (position.y < LowerBorder)
        {
            position.y = LowerBorder;
        }
        
        if (position.x > RightBorder)
        {
            position.x = RightBorder;
        }
        else if (position.x < LeftBorder)
        {
            position.x = LeftBorder;
        }

        return position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Vector3 center = new Vector3((RightBorder + LeftBorder) / 2, (UpperBorder + LowerBorder) / 2, 0);
        Vector3 size = new Vector3(RightBorder - LeftBorder, UpperBorder - LowerBorder, 0);
        Gizmos.DrawWireCube(center, size);
    }
}
