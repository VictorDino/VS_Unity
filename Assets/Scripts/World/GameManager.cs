using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text ammoText;

    public static GameManager Instance {  get; private set; }

    public int Ammo = 10;

    public Text healthText;

    public int health = 100;
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        ammoText.text = Ammo.ToString();
        healthText.text = health.ToString();
    }
}
