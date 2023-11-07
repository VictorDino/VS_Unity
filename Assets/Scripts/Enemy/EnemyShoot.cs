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
    private float timer = 0;private enum EnemyState { Patrolling, Alarm, Tracking, Attacking }
    private EnemyState currentState = EnemyState.Patrolling;
    private Transform player; 

    [Header("Ranges")]
    public float detectionRange = 15f; 
    public float attackRange = 10f; 

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
                // Lógica de patrullaje
                Patrol();
                if (PlayerInDetectionRange())
                {
                    currentState = EnemyState.Alarm;
                }
                break;

            case EnemyState.Alarm:
                // Lógica de alarma
                Alarm();
                if (PlayerInAttackRange())
                {
                    currentState = EnemyState.Attacking;
                    alarmImage.SetActive(false);
                }
                else if (!PlayerInDetectionRange())
                {
                    currentState = EnemyState.Patrolling;
                    alarmImage.SetActive(false);
                }
                break;

            case EnemyState.Tracking:
                // Lógica de seguimiento
                Track();
                if (PlayerInAttackRange())
                {
                    currentState = EnemyState.Attacking;
                }
                else if (!PlayerInDetectionRange())
                {
                    currentState = EnemyState.Patrolling;
                }
                break;

            case EnemyState.Attacking:
                // Lógica de ataque
                Attack();
                if (!PlayerInAttackRange())
                {
                    currentState = EnemyState.Tracking;
                }
                break;
        }
    }

    void Patrol()
    {
         // Implementa la lógica de patrullaje (mueve al enemigo entre puntos de patrulla).
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

    void Alarm()
    {
        alarmImage.SetActive(true);
        // Implementa la lógica de alarma (puede ser una animación, sonido, etc.).
        // En este estado, el enemigo se da cuenta de la presencia del jugador.
    }

    void Track()
    {
        // Implementa la lógica de seguimiento (mueve al enemigo hacia el jugador).
        // Puedes usar NavMesh o simplemente moverlo en la dirección del jugador.
        transform.LookAt(player);
        transform.Translate(Vector3.forward * patrolSpeed * Time.deltaTime);
        EnemyLook();
    }

    void Attack()
    {
        EnemyLook();
        // Lógica de ataque (disparo, animación, etc.).
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
        Debug.DrawRay(transform.position, targetOrientation, Color.green);

        Quaternion targetOrientationQuaternion = Quaternion.LookRotation(targetOrientation);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetOrientationQuaternion, rotationSpeed * Time.deltaTime);
    }
}
