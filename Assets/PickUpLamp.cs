using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{


    public GameObject LampOnPlayer;
    void Start()
    {
        LampOnPlayer.SetActive(false);
    }
    

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);

                LampOnPlayer.SetActive(false);
            }
        }
    }

   
}
