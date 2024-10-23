using UI;
using UnityEngine;

public class HealthDisplayer : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private LoadCapacityDisplayer loadCapacityDisplayer;

    private void OnEnable()
    {
        health.OnHealthReseted += DisplayDefaultHealth;
        health.OnHealthReseted += DisplayCurrentHealth;
        health.OnHealthChanged += DisplayCurrentHealth;
    }

    private void OnDisable()
    {
        health.OnHealthReseted -= DisplayDefaultHealth;
        health.OnHealthReseted -= DisplayCurrentHealth;
        health.OnHealthChanged -= DisplayCurrentHealth;
    }

    private void DisplayDefaultHealth()
    {
        loadCapacityDisplayer.DisplayCapacity(health.DefaultHealth);
    }

    private void DisplayCurrentHealth()
    {
        loadCapacityDisplayer.DisplayLoad(health.CurrentHealth);
    }
}
