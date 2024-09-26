using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _movementSpeed;
    private MovementField _movementField;

    private void Update()
    {
        transform.position += transform.up * _movementSpeed * Time.deltaTime;
        if (!_movementField.CheckIfInsideField(transform.position))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out IDestroyable destroyable))
        {
            destroyable.Destroy();
        }
        Destroy(gameObject);
    }

    public void ProgramProjectile(float projectileSpeed, MovementField movementField)
    {
        _movementSpeed = projectileSpeed;
        _movementField = movementField;
    }
}
