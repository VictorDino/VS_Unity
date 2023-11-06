using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnmy : MonoBehaviour
{
    public float speed = 2f;
    void Start()
    {
        Destroy(gameObject,5f);
    }

    
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "player")
        {
            Destroy(gameObject);
        }
    }
}
