using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _movementSpeed;

    private void Update()
    {
        transform.position += transform.up * _movementSpeed * Time.deltaTime;
    }

    public void SetSpeed(float projectileSpeed)
    {
        _movementSpeed = projectileSpeed;
    }
}
