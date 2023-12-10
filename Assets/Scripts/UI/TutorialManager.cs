using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject messageUI; // Objeto de interfaz de usuario (UI) que mostrará el mensaje
    public float messageDuration = 10f; // Duración del mensaje en pantalla
    public GameObject player;
    public GameObject gun;

    private bool showMessage = false;
    private PlayerMovement playerMovement; // Script de movimiento del jugador
    private Gun gunScript;
    private void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>(); // Obtener el script de movimiento del jugador
        gunScript = gun.GetComponent<Gun>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            showMessage = true;
            messageUI.SetActive(true);
            playerMovement.enabled = false; // Deshabilitar el script de movimiento del jugador
            gunScript.enabled = false;
            Invoke("HideMessage", messageDuration);
            
        }
    }

    private void HideMessage()
    {
        showMessage = false;
        messageUI.SetActive(false);
        playerMovement.enabled = true; // Habilitar nuevamente el movimiento del jugador
        gunScript.enabled = true;
        Destroy(gameObject);
    }
}


