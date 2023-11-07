using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CanvasManager : MonoBehaviour
{
    public Text ammoText;

    public Gun gun;
    private void Update()
    {
        ammoText.text = gun.currentAmmo.ToString();
        
    }
}
