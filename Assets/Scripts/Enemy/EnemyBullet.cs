using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletSpeed = 10.0f;
    public int damage = 10;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        rb.velocity = transform.forward * bulletSpeed;
    }

    void Update()
    {
        
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);

        CheckCollisionWithPlayer();
    }

    void CheckCollisionWithPlayer()
    {
        
        Vector3 rayDirection = transform.forward;
        float rayDistance = bulletSpeed * Time.deltaTime;
        RaycastHit hit;

        
        if (Physics.Raycast(transform.position, rayDirection, out hit, rayDistance))
        {
            
            CharacterController playerController = hit.collider.GetComponent<CharacterController>();

            if (playerController != null)
            {
                
                PlayerHealth playerHealth = playerController.GetComponent<PlayerHealth>();
                

                if (playerHealth != null)
                {
                    
                    playerHealth.TakeDamage(damage);
                }

                Destroy(gameObject);
            }  
            
        }

        

        Destroy(gameObject,2f) ;
        Debug.DrawRay(transform.position, rayDirection * rayDistance, Color.red);
    }


    private void OnTriggerEnter(Collider other)
    {
        // Destruir la bala si colisiona con un objeto que no sea el jugador o el enemigo
        if (!other.CompareTag("Player") && !other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
