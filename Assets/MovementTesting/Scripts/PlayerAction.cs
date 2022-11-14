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
    public float pickUpForce;

    void Start()
    {
        holding = false;
        pickUpForce = 3f;
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
    }

    void DropObject()
    {
        heldRB.useGravity = true;
        heldRB.drag = 1;
        heldRB.constraints = RigidbodyConstraints.None;

        //heldItem.transform.SetParent(null); 
        heldItem = null;
        heldRB = null;
    }

    void MoveObject()
    {
        if(Vector3.Distance(heldItem.transform.position, holdBox.transform.position) > 0.1f)
        {
            Vector3 moveDirection = (holdBox.transform.position - heldItem.transform.position);
            heldRB.AddForce(moveDirection * pickUpForce);
        }
    }

    void Update()
    {
        if(heldItem != null) 
        {
            MoveObject();        
        }
    
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
                        heldItem.transform.position = holdBox.transform.position;
                    }
                }
            }

            if(holding == false)
            {
                DropObject();
            }
        }

    }
}
