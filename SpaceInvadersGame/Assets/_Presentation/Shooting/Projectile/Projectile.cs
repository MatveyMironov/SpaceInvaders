using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _movementSpeed;

    private void Update()
    {
        transform.position += transform.up * _movementSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out IDestroyable destroyable))
        {
            destroyable.Destroy();
        }
        Destroy(gameObject);
    }

    public void SetSpeed(float projectileSpeed)
    {
        _movementSpeed = projectileSpeed;
    }
}
