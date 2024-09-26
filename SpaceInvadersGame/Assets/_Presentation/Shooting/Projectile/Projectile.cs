using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float MovementSpeed;

    void Update()
    {
        transform.position += transform.up * MovementSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out IDestroyable destroyable))
        {
            destroyable.Destroy();
        }
        Destroy(gameObject);
    }
}
