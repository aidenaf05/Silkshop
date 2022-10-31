using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public GameObject player;
    public GameObject holdBox;
    public bool holding;

    void Start()
    {
        holding = false;
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Collider[] hitColliders = Physics.OverlapSphere(holdBox.transform.position, 1f);
            foreach (var hitCollider in hitColliders)
            {
                if(hitCollider.CompareTag("Objects"))
                {
                    Debug.Log("Object Interaction");
                    hitCollider.transform.position = holdBox.transform.position;
                }
            }
        }
    }
}
