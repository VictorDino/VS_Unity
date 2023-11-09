using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 1f;

    private float nextTimeToFire = 0f;

    public int maxAmmo = 10;
    public int currentAmmo = 0;
    public float reloadTime = 3f;
    private bool isReloading = false;

    private AudioSource audioSource;
    private AudioSource audioSource2;

    public AudioClip shootSound;
    public AudioClip reloadSound;

    public Camera fpsCam;

    public Animator animator;

    public ParticleSystem shootEffect;
    public GameObject impactEffect;

    public Text ammoText;


    private void Start()
    {
        currentAmmo = maxAmmo;
        audioSource = GetComponent<AudioSource>();
        audioSource2 = GetComponent<AudioSource>();
        
    }

    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }
    private void Update()
    {
        if (isReloading)
        {
            return;
        }

        if (currentAmmo <= 0) 
        {
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetButtonDown("Fire1")&& Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
            
        }
        ammoText.text = currentAmmo.ToString();
    }

    private void Shoot()
    {
        shootEffect.Play();
        audioSource.PlayOneShot(shootSound);
        currentAmmo --;
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();


            if (target != null)
            {
                target.takeDamage(damage);
            }

            DianaDown dianaDown = hit.transform.GetComponent<DianaDown>();

            if (dianaDown != null)
            {
                dianaDown.takeDamage(damage);
            }


            GameObject impactOG = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactOG, 1f);
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        audioSource2.PlayOneShot(reloadSound);
        Debug.Log("reloading");
        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime);
        animator.SetBool("Reloading", false);
        currentAmmo = maxAmmo;
        isReloading=false;
    }
}
