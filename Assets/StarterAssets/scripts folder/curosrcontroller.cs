using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curosrcontroller : MonoBehaviour
{
    public Material glowMaterial; // Assign your glow material in the Inspector

    private Dictionary<GameObject, Material> originalMaterials = new Dictionary<GameObject, Material>();
    private GameObject lastInteractableObject = null;

    private void Start()
    {
        // Store the original materials for all pickup objects
        StoreOriginalMaterials();
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;

            // If the raycast hits an object tagged as "Pickup"
            if (hitObject.CompareTag("Pickup"))
            {
                // Enable the glow effect
                SetGlow(hitObject, true);

                // Keep track of the last interactable object
                lastInteractableObject = hitObject;
            }
            else
            {
                // Disable the glow effect on the last interactable object
                if (lastInteractableObject != null)
                {
                    SetGlow(lastInteractableObject, false);
                    lastInteractableObject = null;
                }
            }
        }
        else
        {
            // Disable the glow effect if no object is hit
            if (lastInteractableObject != null)
            {
                SetGlow(lastInteractableObject, false);
                lastInteractableObject = null;
            }
        }
    }

    private void StoreOriginalMaterials()
    {
        // Find all pickup objects and store their original materials
        GameObject[] pickupObjects = GameObject.FindGameObjectsWithTag("Pickup");
        foreach (GameObject obj in pickupObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                originalMaterials[obj] = renderer.material;
            }
        }
    }

    private void SetGlow(GameObject obj, bool shouldGlow)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            if (shouldGlow)
            {
                renderer.material = glowMaterial;
            }
            else
            {
                // Revert to the original material
                if (originalMaterials.ContainsKey(obj))
                {
                    renderer.material = originalMaterials[obj];
                }
            }
        }
    }
}
