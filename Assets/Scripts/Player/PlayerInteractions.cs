using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ammo"))
        {
            GameManager.Instance.Ammo += other.gameObject.GetComponent<AmmoBox>().ammo;
            Destroy(other.gameObject);
        }
    }
}
