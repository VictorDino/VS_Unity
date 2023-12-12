using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAim : MonoBehaviour
{
    public Transform target;
    void Update()
    {
        Vector3 targetOrientation = target.position - transform.position;
        Debug.DrawRay(transform.position, targetOrientation, Color.green);

        transform.rotation = Quaternion.LookRotation(targetOrientation);

        Quaternion targetOrientationQuaternion = Quaternion.LookRotation(targetOrientation);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetOrientationQuaternion, Time.deltaTime);
    }
}
