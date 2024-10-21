using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Gun gun;

    public void Shoot()
    {
        gun.Shoot();
    }
}
