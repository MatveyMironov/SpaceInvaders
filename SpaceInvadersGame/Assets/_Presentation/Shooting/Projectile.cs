using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float MovementSpeed;

    void Update()
    {
        transform.position += transform.up * MovementSpeed * Time.deltaTime;
    }
}
