using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update

    private const int maxHealth = 100;
    [SerializeField] private int health;

    public static event Action onPlayerDeath;
    public void ResetHealth()
    {
        health = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Police"))
        {
            health -= 50;
            if (health <= 0)
            {
                onPlayerDeath?.Invoke(); //if onPlayerDeath is not null, then invoke it
            }
        }
    }

}

