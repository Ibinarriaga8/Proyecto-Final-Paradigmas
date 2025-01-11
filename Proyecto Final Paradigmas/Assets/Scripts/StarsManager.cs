using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsManager : MonoBehaviour
{
    public Image[] stars;  // Un array de imágenes de estrellas
    public int level;      // Nivel de búsqueda

    void Update()
    {
        // Cambiar color de las estrellas según el nivel
        for (int i = 0; i < stars.Length; i++)
        {
            if (i < level)
            {
                stars[i].color = Color.yellow;  // Amarillo si la estrella está activa
            }
            else
            {
                stars[i].color = Color.black;   // Negra si la estrella está inactiva
            }
        }
    }

    // Método para actualizar el nivel de búsqueda
    public void SetLevel(int newLevel)
    {
        level = newLevel;
    }
}
