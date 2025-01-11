using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int currentLevel = 1; // Nivel actual
    [SerializeField] private const int maxLevel = 5; // Nivel máximo
    [SerializeField] private Transform spawnPosition; // Posición de spawn del jugador
    [SerializeField] private GameObject player;
    [SerializeField] private StarsManager starsManager;


    private void OnEnable()
    {
        RaceCarTarget.onTargetReached += HandleTargetReached;
        PlayerHealth.onPlayerDeath += RaceCar_onPlayerDeath;
        starsManager.SetLevel(currentLevel);
    }

    private void OnDisable()
    {
        RaceCarTarget.onTargetReached -= HandleTargetReached;
        PlayerHealth.onPlayerDeath -= RaceCar_onPlayerDeath;
    }


    private void LoadLevel(int level)
    {
        Debug.Log($"Cargando Nivel {level}");
        starsManager.SetLevel(level);

        ClearEnemies(); // Eliminar enemigos previos

        if (level <= maxLevel)
        {

            ResetPlayer();
            SpawnEnemies(level);
        }
        else
        {
            HandleWin();
        }
    }

    private void ResetPlayer()
    {
        // Resetear la velocidad y rotación del jugador
        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true; // Desactiva la física temporalmente
        }

        // Mover al jugador al punto de spawn
        Debug.Log("Moviendo jugador al punto de spawn...");
        player.transform.position = spawnPosition.position;
        player.transform.rotation = Quaternion.identity; // Resetear rotación

        // Reactivar el Rigidbody
        if (rb != null)
        {
            rb.isKinematic = false; // Reactiva la física
            rb.velocity = Vector3.zero; // Eliminar velocidad lineal
            rb.angularVelocity = Vector3.zero; // Eliminar rotación
            rb.WakeUp(); // Asegura que el Rigidbody esté activo en la física
        }
        player.SetActive(false);
        player.SetActive(true);


        // Resetear la salud del jugador
        player.GetComponent<PlayerHealth>().ResetHealth();

    }


    //Player onto the next level
    private void HandleTargetReached()
    {
        Debug.Log($"¡Nivel {currentLevel} completado!");

        currentLevel++;

        if (currentLevel > maxLevel)
        {
            HandleWin();
        }
        else
        {
            LoadLevel(currentLevel);
        }
    }
    private void HandleWin()
    {
        Debug.Log("¡Has ganado el juego! 🎉");
        //Pasar a la siguiente escena:
        
    }

    private void SpawnEnemies(int level)
    {
        Debug.Log($"Spawning enemies for level {level}");
    }

    private void ClearEnemies()
    {
        Debug.Log("Clearing enemies...");
    }

    /// <summary>
    /// Manejar la muerte del jugador.
    /// </summary>
    private void RaceCar_onPlayerDeath()
    {
        Debug.Log("El jugador ha muerto. Reiniciando nivel...");
        LoadLevel(currentLevel); // Reiniciar el nivel actual
    }

}


