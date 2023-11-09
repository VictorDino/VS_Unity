using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealthBar : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;
    void LateUpdate()
    {
        transform.position= Camera.main.WorldToScreenPoint(target.position + offset);
    }
}
