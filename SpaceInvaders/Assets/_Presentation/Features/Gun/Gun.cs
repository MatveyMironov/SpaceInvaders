using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;

    [SerializeField] private Transform muzzle;

    [SerializeField] private float projectileSpeed;
    [SerializeField] private LayerMask hitableLayers;
    [SerializeField] private float effectiveDistance;
    [SerializeField] private float cooldownTime;

    private bool _isOnCooldown;

    public void Shoot()
    {
        if (_isOnCooldown) { return; }

        Projectile projectile = Instantiate(projectilePrefab, muzzle.position, muzzle.rotation);
        float deathTime = effectiveDistance / projectileSpeed;
        projectile.SetupProjectile(projectileSpeed, hitableLayers, deathTime);

        _isOnCooldown = true;
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldownTime);

        _isOnCooldown = false;
    }
}
