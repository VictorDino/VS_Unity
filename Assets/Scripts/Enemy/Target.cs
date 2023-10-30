using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 30f;

    public void takeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
