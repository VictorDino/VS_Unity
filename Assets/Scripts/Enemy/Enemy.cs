using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void Start()
    {
        EnemyManager.instance.RegisterEnemy(gameObject);
    }

    private void OnDestroy()
    {
        if (EnemyManager.instance != null)
            EnemyManager.instance.OnEnemyDeath(gameObject);
    }
}
