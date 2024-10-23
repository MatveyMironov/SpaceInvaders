using UnityEngine;

public class Player : MonoBehaviour, IHitable
{
    [SerializeField] private Health health;

    public void Hit()
    {
        health.RemoveHealth(1);
    }
}
