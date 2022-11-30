using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTest : MonoBehaviour
{
    public bool direction;
    public Rigidbody target;
    public float targetx;

    void Start()
    {
        targetx = 0f;
        direction = false;
        InvokeRepeating("DirectionSwap", 0f, 2f);
    }

    void DirectionSwap()
    {
        direction = !direction;
        targetx = 0f;
    }

    void Update()
    {
        if(direction == false)
        {
            targetx += 1f * Time.deltaTime;
        }
        else if(direction == true)
        {
            targetx -= 1f * Time.deltaTime;
        }
        target.velocity = new Vector3(targetx, 0f, 0f); 
    }

}
