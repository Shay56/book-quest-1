using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupanddrop : MonoBehaviour
{
    public string pickupTag = "Pickup";
    private GameObject carriedObject = null;

    void Update()
    {
        if (carriedObject == null)
        {
           
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
            {
                if (hit.transform.CompareTag(pickupTag))
                {
                    if (Input.GetKeyDown(KeyCode.E)) 
                    {
                        carriedObject = hit.transform.gameObject;
                        Rigidbody rb = carriedObject.GetComponent<Rigidbody>();
                        rb.isKinematic = true;
                        carriedObject.transform.SetParent(transform);
                    }
                }
            }
        }
        else
        {
           
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                Rigidbody rb = carriedObject.GetComponent<Rigidbody>();
                rb.isKinematic = true;
                carriedObject.transform.SetParent(null);
                carriedObject = null;
            }
        }
    }
}
