using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth; 

    public Text healthText;

    void Start()
    {
        currentHealth = maxHealth;
        
    }


    public void TakeDamage(int damage)
    {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Debug.Log("El jugador ha muerto.");
                SceneManager.LoadScene("Level");
            }
        
        UpdateHealthText();
    }

    public void UpdateHealthText()
    {
        
        healthText.text = currentHealth.ToString();
    }

    public void RestoreHealthToMax()
    {
        currentHealth = maxHealth;
    }
}

