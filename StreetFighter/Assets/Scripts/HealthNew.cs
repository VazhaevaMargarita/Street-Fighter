using System;
using UnityEngine;

public class HealthNew : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHealth = 100;

    public int CurrentHealth { get; private set; }

    public int MaxHealth => maxHealth;

    public event Action<int, int> HealthChanged;
    public event Action Died;

    private bool isDead;

    private void Awake()
    {
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
            return;

        CurrentHealth -= damage;

        if (CurrentHealth < 0)
            CurrentHealth = 0;

        HealthChanged?.Invoke(CurrentHealth, maxHealth);

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        Died?.Invoke();
    }
}