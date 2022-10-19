using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAI : MonoBehaviour
{
    void Start()
    {
        WalkTo(new Vector3(0, 1, 10));
    }

    void Update()
    {
        
    }

    void WalkTo(Vector3 dest) 
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(dest);
    }
}
