using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void Start()
    {
        // Registrarse en el manager de enemigos al ser creado
        EnemyManager.instance.RegisterEnemy(gameObject);
    }

    private void OnDestroy()
    {
        // Notificar al manager cuando el enemigo es destruido
        if (EnemyManager.instance != null)
            EnemyManager.instance.OnEnemyDeath(gameObject);
    }
}
