using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbingscript : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("E")) // Replace "Fire1" with your input for grabbing
        {
            audioSource.Play();
        }
    }
}