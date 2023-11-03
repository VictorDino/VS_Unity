using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DianaDown : MonoBehaviour
{
    public float maxHealth = 30f;
    public float currentHealth;

    public Animator animator;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void takeDamage(float amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            animator.SetBool("isDown", true);
            currentHealth = maxHealth;
        }
    }

}
