using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [Header("Shooting Options")]
    public GameObject projectile;
    public Transform[] firePoints;
    public float bulletSpeed = 10.0f;
    public AudioClip shoot;
    public float timeBetweenShots = 3f;
    private float timer = 0;

    private enum EnemyState { Patrolling, TrackingAndAttacking }
    private EnemyState currentState = EnemyState.Patrolling;
    private Transform player;

    [Header("Ranges")]
    public float detectionRange = 15f;
    public float attackRange = 10f;
    public float stoppingDistance = 5.0f; // Distancia para mantener una distancia al jugador

    [Header("States")]
    public float patrolSpeed = 5f;
    public Transform[] patrolPoints;
    private int currentPatrolPointIndex = 0;

    [Header("Others")]
    public Transform target;
    public GameObject alarmImage;
    public float rotationSpeed = 10f;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        alarmImage.SetActive(false);
    }

    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Patrolling:
                Patrol();
                if (PlayerInDetectionRange())
                {
                    currentState = EnemyState.TrackingAndAttacking;
                }
                break;

            case EnemyState.TrackingAndAttacking:
                TrackAndAttack();
                if (!PlayerInDetectionRange())
                {
                    currentState = EnemyState.Patrolling;
                }
                break;
        }

        alarmImage.SetActive(currentState == EnemyState.TrackingAndAttacking);
    }

    void Patrol()
    {
        // Implementa la lógica de patrullaje
        if (Vector3.Distance(transform.position, patrolPoints[currentPatrolPointIndex].position) < 0.2f)
        {
            currentPatrolPointIndex = (currentPatrolPointIndex + 1) % patrolPoints.Length;
        }

        // Calcula la dirección hacia el siguiente punto de patrulla.
        Vector3 patrolDirection = (patrolPoints[currentPatrolPointIndex].position - transform.position).normalized;

        // Mueve al enemigo hacia el siguiente punto de patrulla.
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPatrolPointIndex].position, patrolSpeed * Time.deltaTime);

        // Haz que el enemigo mire en la dirección del movimiento.
        transform.LookAt(transform.position + patrolDirection);
    }

    void TrackAndAttack()
    {
        transform.LookAt(player);

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > stoppingDistance)
        {
            // Mueve al enemigo hacia el jugador solo si está más lejos que la distancia de parada
            transform.Translate(Vector3.forward * patrolSpeed * Time.deltaTime);
        }

        EnemyLook();

        if (PlayerInAttackRange())
        {
            Attack();
        }
    }

    void Attack()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenShots)
        {
            timer = 0.0f;
            foreach (Transform firePoint in firePoints)
            {
                ShootFromPoint(firePoint);
            }
        }
    }

    private bool PlayerInDetectionRange()
    {
        return Vector3.Distance(transform.position, player.position) < detectionRange;
    }

    private bool PlayerInAttackRange()
    {
        return Vector3.Distance(transform.position, player.position) < attackRange;
    }

    private void ShootFromPoint(Transform firePoint)
    {
        GameObject newProjectile = Instantiate(projectile, firePoint.position, firePoint.rotation);
        newProjectile.GetComponent<Rigidbody>().velocity = firePoint.forward * bulletSpeed;
        AudioSource.PlayClipAtPoint(shoot, transform.position);
    }

    private void EnemyLook()
    {
        Vector3 targetOrientation = target.position - transform.position;
        Quaternion targetOrientationQuaternion = Quaternion.LookRotation(targetOrientation);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetOrientationQuaternion, rotationSpeed * Time.deltaTime);
    }
}
