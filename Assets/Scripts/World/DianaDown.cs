using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DianaDown : MonoBehaviour
{
    public float maxHealth = 30f;
    public float currentHealth;
    public Animator animator;

    public float resetDelay = 3.0f;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            animator.SetBool("isDown", true);
            Invoke("ResetHealth", resetDelay);
        }
    }

    void ResetHealth()
    {
        currentHealth = maxHealth;
        animator.SetBool("isDown", false);
    }
}

