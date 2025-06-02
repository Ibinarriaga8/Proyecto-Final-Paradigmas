using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private const int maxHealth = 100;
    [SerializeField] private int health;
    private int numLives = 10;

    public int Health { get => health; set { health = value; OnHealthChanged?.Invoke(health); } }

    public static event Action<int> OnHealthChanged;
    public static event Action<int> OnLivesChanged; // Nuevo evento para vidas
    public static event Action onPlayerDeath; 
    public static event Action<bool> onGameEnded;
    // M�todo para resetear la salud del jugador
    public void ResetHealth()
    {
        health = maxHealth;
        OnHealthChanged?.Invoke(health);
    }

    // M�todo para que el jugador reciba da�o
    public void TakeDamage(int damage)
    {
        health -= damage;


        if (health <= 0)
        {
            health = 0;

            numLives--;
            if (numLives <= 0)
            {
                onGameEnded?.Invoke(false); // Notifica que el jugador perdi�
            }
            OnLivesChanged?.Invoke(numLives);
            onPlayerDeath?.Invoke(); // Notifica que el jugador muri�
           
        }
        OnHealthChanged?.Invoke(health); // Notifica sobre el cambio de salud
    }
}



