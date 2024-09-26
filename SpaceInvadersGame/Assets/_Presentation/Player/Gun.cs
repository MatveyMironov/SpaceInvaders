using UnityEngine;

public class Gun
{
    public void Shoot(Projectile projectilePrefab, Transform muzzle, float projectileSpeed)
    {
        Projectile projectile = UnityEngine.GameObject.Instantiate(projectilePrefab, muzzle.position, muzzle.rotation);
        projectile.MovementSpeed = projectileSpeed;
    }
}
