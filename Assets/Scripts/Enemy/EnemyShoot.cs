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
    public float stoppingDistance = 5.0f;

    [Header("States")]
    public float patrolSpeed = 3f;
    public float trackSpeed = 5f;
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
        if (Vector3.Distance(transform.position, patrolPoints[currentPatrolPointIndex].position) < 0.2f)
        {
            currentPatrolPointIndex = (currentPatrolPointIndex + 1) % patrolPoints.Length;
        }

        Vector3 patrolDirection = (patrolPoints[currentPatrolPointIndex].position - transform.position).normalized;

        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPatrolPointIndex].position, patrolSpeed * Time.deltaTime);

        transform.LookAt(transform.position + patrolDirection);
    }

    void TrackAndAttack()
    {
        transform.LookAt(player);

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > stoppingDistance)
        {
            transform.Translate(Vector3.forward * trackSpeed * Time.deltaTime);
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
        Vector3 direction = player.position - firePoint.position;
        GameObject newBullet = Instantiate(projectile, firePoint.position, Quaternion.LookRotation(direction));
        newBullet.GetComponent<Rigidbody>().velocity = direction.normalized * 10f;
        AudioSource.PlayClipAtPoint(shoot, transform.position);
    }

    private void EnemyLook()
    {
        Vector3 targetOrientation = target.position - transform.position;
        Quaternion targetOrientationQuaternion = Quaternion.LookRotation(targetOrientation);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetOrientationQuaternion, rotationSpeed * Time.deltaTime);
    }
}
