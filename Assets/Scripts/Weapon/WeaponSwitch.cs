using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject[] weapons;

    public int selectedWeapon = 0;
    void Start()
    {
        selectedWeapon = 0;
    }

    
    void Update()
    {
        int previousWeapon = selectedWeapon;


        if (Input.GetKey(KeyCode.Q))
        {
            if (selectedWeapon >= weapons.Length - 1)
            {
                selectedWeapon = 0;
            }
        }

        if (Input.GetKey(KeyCode.E))
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = weapons.Length - 1;
            }
        }

        if(previousWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform) 
        {
            if(weapon.gameObject.layer == LayerMask.NameToLayer("Weapon"))
            {
                if(i == selectedWeapon)
                {
                    weapon.gameObject.SetActive(true);
                }
                else
                {
                    weapon.gameObject.SetActive(false);
                }

                i++;
            }
        }
    }
}
