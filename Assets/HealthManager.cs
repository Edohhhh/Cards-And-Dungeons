using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public UnityEvent<int> OnHealthChanged; // Evento para notificar cambios en la vida

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Asegura que la vida no sea negativa
        UpdateHealthUI();
        CheckDeath();
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Asegura que la vida no exceda el m�ximo
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        // Aqu� puedes agregar l�gica para actualizar la interfaz de usuario con la vida actual
        Debug.Log("Health: " + currentHealth);
        OnHealthChanged.Invoke(currentHealth); // Notifica a los suscriptores que la vida ha cambiado
    }

    private void CheckDeath()
    {
        if (currentHealth <= 0)
        {
            // Aqu� puedes agregar l�gica para manejar la muerte del jugador
            Debug.Log("Player has died.");
        }
    }
}