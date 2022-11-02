using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public GameObject player;
    public GameObject holdBox;
    public bool holding;
    public GameObject heldItem;

    void Start()
    {
        holding = false;
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
                    }
                }
            }
        }

        if(holding == true)
        {
            heldItem.transform.position = holdBox.transform.position;
            //heldItem.transform.SetParent(holdBox.transform);
        }
    }
}
