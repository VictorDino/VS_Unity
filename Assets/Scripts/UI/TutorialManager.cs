using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject messageUI; 
    public float messageDuration = 10f; 
    public GameObject player;
    public GameObject gun;

    private bool showMessage = false;
    private PlayerMovement playerMovement; 
    private Gun gunScript;
    private void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        gunScript = gun.GetComponent<Gun>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            showMessage = true;
            messageUI.SetActive(true);
            playerMovement.enabled = false;
            gunScript.enabled = false;
            Invoke("HideMessage", messageDuration);
            
        }
    }

    private void HideMessage()
    {
        showMessage = false;
        messageUI.SetActive(false);
        playerMovement.enabled = true;
        gunScript.enabled = true;
        Destroy(gameObject);
    }
}


