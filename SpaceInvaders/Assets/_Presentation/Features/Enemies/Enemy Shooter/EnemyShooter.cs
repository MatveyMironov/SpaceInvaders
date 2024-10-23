using System;
using UnityEngine;

[Serializable]
public class EnemyShooter
{
    [SerializeField] private Projectile projectilePrefab;

    [SerializeField] private float projectileSpeed;
    [SerializeField] private LayerMask hitableLayers;
    [SerializeField] private float effectiveDistance;

    public void Shoot(Transform muzzle)
    {
        Projectile projectile = GameObject.Instantiate(projectilePrefab, muzzle.position, muzzle.rotation);
        float deathTime = effectiveDistance / projectileSpeed;
        projectile.SetupProjectile(projectileSpeed, hitableLayers, deathTime);
    }
}
