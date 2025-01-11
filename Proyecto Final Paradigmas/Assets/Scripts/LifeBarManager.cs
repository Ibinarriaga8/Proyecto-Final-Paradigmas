using UnityEngine;
using UnityEngine.UI;

public class LifeBarManager : MonoBehaviour
{
    [SerializeField] private Slider lifeBar; // Referencia al Slider de la barra de vida

    private void Awake()
    {
        if (lifeBar != null)
        {
            lifeBar.minValue = 0;
            lifeBar.maxValue = 100; // Vida máxima
            UpdateLifeBar(100);
        }
    }

    private void OnEnable()
    {
        // Suscribirse al evento OnHealthChanged
        PlayerHealth.OnHealthChanged += UpdateLifeBar;
    }

    private void OnDisable()
    {
        // Desuscribirse del evento OnHealthChanged para evitar errores
        PlayerHealth.OnHealthChanged -= UpdateLifeBar;
    }

    public void UpdateLifeBar(int currentHealth)
    {

        if (lifeBar != null)
        {
            lifeBar.value = currentHealth;
        }
    }
}