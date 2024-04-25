using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickable : MonoBehaviour
{
    private Material originalMaterial;
    public Material glowMaterial; // Assign the glow material in the Inspector

    void Start()
    {
        // Store the original material
        originalMaterial = GetComponent<Renderer>().material;
    }

    public void SetGlow(bool glow)
    {
        if (glow)
        {
            GetComponent<Renderer>().material = glowMaterial;
        }
        else
        {
            GetComponent<Renderer>().material = originalMaterial;
        }
    }
}
