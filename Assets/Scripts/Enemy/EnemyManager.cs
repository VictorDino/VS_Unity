using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    private List<GameObject> enemies = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void RegisterEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
    }

    public void UnregisterEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);

        
        if (enemies.Count == 0)
        {
            
            SceneManager.LoadScene("MainMenu");
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void OnEnemyDeath(GameObject enemy)
    {
        UnregisterEnemy(enemy);
    }
}

