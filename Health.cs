using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event EventHandler OnHealthChanged;
    public event EventHandler OnHealthMaxChanged;
    public event EventHandler OnDamaged;
    public event EventHandler OnHealed;
    public event EventHandler OnDead;

    private int healthMax;
    private int health;

    public Health(int healthMax)
    {
        this.healthMax = healthMax;
        health = healthMax;
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetMaxHealth()
    {
        return healthMax;
    }

    public void Damage(int amount)
    {
        health -= amount;
        if(health < 0)
        {
            health = 0;
        }

        OnHealthChanged?.Invoke(this, EventArgs.Empty);
        OnDamaged?.Invoke(this, EventArgs.Empty);

        if (health <= 0)
        {
            Die();
        }
    }

    public bool isDead()
    {
        return health <= 0;
    }

    public void Die()
    {
        OnDead?.Invoke(this, EventArgs.Empty);
    }
}
