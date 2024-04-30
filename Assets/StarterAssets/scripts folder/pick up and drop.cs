using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupanddrop : MonoBehaviour
{
    public string pickupTag = "Pickup";
    private GameObject carriedObject = null;
    private AudioSource audioSourcePickup;  // AudioSource for pickup sound
    public AudioClip dropSound;  // AudioClip for drop sound

    void Start()
    {
        // Get the AudioSource component for pickup sound
        audioSourcePickup = GetComponent<AudioSource>();
    }

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

                        audioSourcePickup.Play();  // Play the pickup sound effect
                    }
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Rigidbody rb = carriedObject.GetComponent<Rigidbody>();
                rb.isKinematic = false;
                carriedObject.transform.SetParent(null);
                carriedObject = null;
            }
        }
    }

    // This function is called when the item collides with another object
    void OnCollisionEnter(Collision collision)
    {
        // Check if the item has collided with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Item collided with the ground");  // Log a message
            // Play the drop sound effect
            AudioSource.PlayClipAtPoint(dropSound, transform.position);
        }
    }
}
