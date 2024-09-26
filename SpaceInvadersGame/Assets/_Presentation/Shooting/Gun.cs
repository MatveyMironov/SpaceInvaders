using UnityEngine;

public class Gun
{
    private bool _isRecharging;
    private float _rechargingTimer;

    public void FunctioningTick(float rechargingTime)
    {
        if (_isRecharging)
        {
            _rechargingTimer += Time.deltaTime;
            if (_rechargingTimer > rechargingTime)
            {
                _isRecharging = false;
                _rechargingTimer = 0;
            }
        }
    }

    public void Shoot(Projectile projectilePrefab, Transform muzzle, float projectileSpeed, MovementField movementField)
    {
        if (_isRecharging)
            return;

        Projectile projectile = UnityEngine.GameObject.Instantiate(projectilePrefab, muzzle.position, muzzle.rotation);
        projectile.ProgramProjectile(projectileSpeed, movementField);
        _isRecharging = true;
    }
}
