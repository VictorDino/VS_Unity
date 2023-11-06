using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 30f;

    public ParticleSystem destroyEffect;

    public AudioClip explosion;
    public void takeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            destroyEffect.Play();
            AudioSource.PlayClipAtPoint(explosion, transform.position);
            Destroy(gameObject, 0.3f);
            
        }
    }
}
