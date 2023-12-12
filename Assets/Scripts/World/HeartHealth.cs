using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartHealth : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.RestoreHealthToMax();
                playerHealth.UpdateHealthText();
                Destroy(gameObject);
            }
        }
    }
}
