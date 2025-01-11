using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int currentLevel = 1; // Nivel actual
    [SerializeField] private const int maxLevel = 5; // Nivel máximo
    [SerializeField] private const int maxLives = 10; // Número de vidas
    [SerializeField] private Transform spawnPosition; // Posición de spawn del jugador
    [SerializeField] private GameObject player;
    private List<PoliceCar> policeCars = new List<PoliceCar>();
    bool levelFirstTime = true;


    //Posición de spawn Police
    [SerializeField] private List<Transform> policeSpawnPositions;


    [SerializeField] private HeartManager heartManager;
    [SerializeField] private StarsManager starsManager;


    private void OnEnable()
    {
        RaceCarTarget.onTargetReached += HandleTargetReached;
        PlayerHealth.onPlayerDeath += RaceCar_onPlayerDeath;
        PlayerHealth.onGameEnded += HandleGameOver;
        starsManager.SetLevel(currentLevel);
        heartManager.UpdateHearts(maxLives);
    }

    private void OnDisable()
    {
        RaceCarTarget.onTargetReached -= HandleTargetReached;
        PlayerHealth.onPlayerDeath -= RaceCar_onPlayerDeath;
        PlayerHealth.onGameEnded -= HandleGameOver;

    }


    private void LoadLevel(int level)
    {
        Debug.Log($"Cargando Nivel {level}");
        starsManager.SetLevel(level);

        if (level <= maxLevel)
        {

            ResetPlayer();
            if (level > 1)
            {
                ResetEnemies();
                if (levelFirstTime)
                    SpawnEnemies(level);
                
            }
        }
        
        levelFirstTime = false;
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
        levelFirstTime = true;

        currentLevel++;

        if (currentLevel > maxLevel)
        {
            HandleGameOver(true);
        }
        else
        {
            LoadLevel(currentLevel);
        }
    }
    private void HandleGameOver(bool win)
    {
        if (win)
        {
            Debug.Log("¡Has ganado!");
            SceneManager.LoadScene(3);
        }
        else
        {
            Debug.Log("¡Has perdido!");
            SceneManager.LoadScene(2);
        }

    }

    private void SpawnEnemies(int level)
    {
        Debug.Log($"Spawning enemies for level {level}");

        //Spawn corresponging police car for each level
        PoliceCar policeCar = PoliceCarFactory.Instance.SpawnObstacle(policeSpawnPositions[level - 2].position) as PoliceCar;
        policeCars.Add(policeCar);
        
    }

    private void ResetEnemies()
    {
        for (int i = 0; i < policeCars.Count; i++)
        {
            policeCars[i].transform.position = policeSpawnPositions[i].position;
        }
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


