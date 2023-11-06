using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectile;
    public Transform[] firePoints;
    public float bulletSpeed = 10.0f;
    public AudioClip shoot;
    public float timeBetweenShots = 3f;
    private float timer = 0;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenShots)
        {
            timer = 0.0f;
            foreach (Transform firePoint in firePoints)
            {
                GameObject newProjectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
                newProjectile.transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
                AudioSource.PlayClipAtPoint(shoot, transform.position);
            }
        }
    }
}
