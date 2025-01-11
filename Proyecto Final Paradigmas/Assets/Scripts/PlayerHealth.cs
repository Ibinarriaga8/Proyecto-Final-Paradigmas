using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update

    private const int maxHealth = 100;
    [SerializeField] private int health;
    public int Health { get => health; set { health = value; }  }

    public static event Action onPlayerDeath;
    public void ResetHealth()
    {
        health = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            onPlayerDeath?.Invoke(); //if onPlayerDeath is not
        }
    }

}

