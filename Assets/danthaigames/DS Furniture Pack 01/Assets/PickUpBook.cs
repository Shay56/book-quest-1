using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBook : MonoBehaviour
{


    public GameObject PickUpBookOnPlayer;


    void Start()
    {
        PickUpBookOnPlayer.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);

                PickUpBookOnPlayer.SetActive(true);
            }
        }
    }

    
}
