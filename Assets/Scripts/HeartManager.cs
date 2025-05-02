using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    [SerializeField] private Image[] hearts;

    private void OnEnable()
    {
        PlayerHealth.OnLivesChanged += UpdateHearts;
    }

    private void OnDisable()
    {
        PlayerHealth.OnLivesChanged -= UpdateHearts;
    }

    // Actualiza la visualización de los corazones
    public void UpdateHearts(int lives)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < lives)
            {
                hearts[i].color = Color.red;
            }
            else
            {
                hearts[i].color = Color.black;
            }
        }
    }
}