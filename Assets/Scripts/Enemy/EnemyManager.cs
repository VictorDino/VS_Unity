using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance; // Singleton para acceder desde otros scripts

    private List<GameObject> enemies = new List<GameObject>(); // Lista de enemigos en la escena

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject); // Para mantener el manager entre escenas
    }

    public void RegisterEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
    }

    public void UnregisterEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);

        // Verificar si no hay más enemigos
        if (enemies.Count == 0)
        {
            // Ejemplo: Cambiar a una nueva escena
            SceneManager.LoadScene("MainMenu");
            Cursor.lockState = CursorLockMode.None;
        }
    }

    // Método para llamar desde otros scripts cuando un enemigo es destruido
    public void OnEnemyDeath(GameObject enemy)
    {
        UnregisterEnemy(enemy);
    }
}

