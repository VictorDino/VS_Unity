using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float maxHealth = 30f;
    public float currentHealth;
    public ParticleSystem destroyEffect;
    public AudioClip explosion;
    public Slider healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            destroyEffect.Play();
            AudioSource.PlayClipAtPoint(explosion, transform.position);
            Destroy(gameObject, 0.3f);
        }
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthBar.value = currentHealth;
    }
}
