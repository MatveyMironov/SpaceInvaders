using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int defaultHealth;

    public int DefaultHealth { get => defaultHealth; }
    public int CurrentHealth { get; private set; }

    public event Action OnHealthReseted;
    public event Action OnHealthChanged;
    public event Action OnHealthExpired;

    private void Start()
    {
        ResetHealth();
    }

    [ContextMenu("Reset Health")]
    public void ResetHealth()
    {
        CurrentHealth = DefaultHealth;
        OnHealthReseted?.Invoke();
        CheckForExpired();
    }

    public void AddHealth(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException("Can't add negative or zero amount of health");
        }

        if (CurrentHealth + amount > DefaultHealth)
        {
            CurrentHealth = DefaultHealth;
        }
        else
        {
            CurrentHealth += amount;
        }

        OnHealthChanged?.Invoke();
    }

    public void RemoveHealth(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException("Can't subtract negative or zero amount of health");
        }

        if (CurrentHealth < amount)
        {
            CurrentHealth = 0;
        }
        else
        {
            CurrentHealth -= amount;
        }

        OnHealthChanged?.Invoke();
        CheckForExpired();
    }

    private void CheckForExpired()
    {
        if (CurrentHealth <= 0)
        {
            OnHealthExpired?.Invoke();
        }
    }
}
