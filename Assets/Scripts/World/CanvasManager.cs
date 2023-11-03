using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CanvasManager : MonoBehaviour
{
    public Text ammoText;

    public Text healthText;

    public Gun gun;

    public int health = 100;
    private void Update()
    {
        ammoText.text = gun.currentAmmo.ToString();
        healthText.text = health.ToString();
    }
}
