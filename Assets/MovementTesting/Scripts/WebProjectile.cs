using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebProjectile : MonoBehaviour
{
    public GameObject projectile; 
    public float projSpeed;

    void Start()
    {
        projSpeed = 20f;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Objects"))
        {
            //collision.gameObject.Rigidbody.constraints = RigidbodyConstraints.FreezePosition;
        }
        Destroy(projectile);
    }

    void Update()
    {
        projectile.transform.position += transform.forward * projSpeed * Time.deltaTime;
    }
}
