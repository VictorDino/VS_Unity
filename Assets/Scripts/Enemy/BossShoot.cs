using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public Transform player;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    public float detectionRange = 10f;
    private float nextFireTime = 0f;
    public AudioClip shoot;

    void Update()
    {
        bool inRange = PlayerInRange();

        if (inRange && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    bool PlayerInRange()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        return distance <= detectionRange;
    }

    void Shoot()
    {
        Vector3 direction = player.position - firePoint.position;
        GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(direction));
        newBullet.GetComponent<Rigidbody>().velocity = direction.normalized * 10f;
        AudioSource.PlayClipAtPoint(shoot, transform.position);
    }
}