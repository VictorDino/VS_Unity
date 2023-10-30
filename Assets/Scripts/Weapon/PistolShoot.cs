using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolShoot : MonoBehaviour
{
    public Transform spawnPoint;

    public GameObject bullet;

    public float shootForce = 5000f;

    public float shootRate = 0.5f;

    private float shootRateTime = 0;


    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            if (GameManager.Instance.Ammo > 0)
            {
                GameManager.Instance.Ammo --;

                if (Time.time > shootRateTime)
                {
                    GameObject newBullet;

                    newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

                    newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shootForce);

                    shootRateTime = Time.time + shootRate;

                    Destroy(newBullet, 2);
                }
            }
        }

    }

}
