using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public GameObject player;
    public GameObject holdBox;
    public bool holding;
    public GameObject heldItem;
    public Rigidbody heldRB;

    void Start()
    {
        holding = false;
    }

    void PickupObject() 
    {
        if(holding == true)
        {
            heldRB = heldItem.GetComponent<Rigidbody>();
            heldRB.useGravity = false;
            heldRB.drag = 10;
            heldRB.constraints = RigidbodyConstraints.FreezeRotation;

            //heldItem.transform.SetParent(holdBox); 
        }

        if(holding == false) {
            heldRB.useGravity = true;
            heldRB.drag = 1;
            heldRB.constraints = RigidbodyConstraints.None;

            heldItem.transform.SetParent(null); 
            heldItem = null;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            holding = !holding;

            if(holding == true)
            {
                Collider[] hitColliders = Physics.OverlapSphere(holdBox.transform.position, 1f);
                foreach (var hitCollider in hitColliders)
                {
                    if(hitCollider.CompareTag("Objects"))
                    {
                        Debug.Log("Object Interaction");
                        holding = true;
                        heldItem = hitCollider.gameObject;
                        PickupObject();
                    }
                }
            }
        }

    }
}
