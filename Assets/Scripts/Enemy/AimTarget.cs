using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTarget : MonoBehaviour
{
    public Transform target;

    public float rotationSpeed = 10f;
    void Start()
    {
        
    }

    
    void Update()
    {
        Vector3 targetOrientation = target.position - transform.position;
        Debug.DrawRay(transform.position, targetOrientation, Color.green);

        Quaternion targetOrientationQuaternion = Quaternion.LookRotation(targetOrientation);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetOrientationQuaternion,rotationSpeed *Time.deltaTime);
    }
}
