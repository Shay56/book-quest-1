using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookRespawner : MonoBehaviour
{
    public GameObject[] bookPrefabs; // Assign your book prefabs in the Inspector
    public Transform[] spawnPoints; // Assign spawn points on the counter in the Inspector

    public void RespawnBooks()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            // Choose a random book prefab
            GameObject bookPrefab = bookPrefabs[Random.Range(0, bookPrefabs.Length)];

            // Instantiate the book at the spawn point
            GameObject newBook = Instantiate(bookPrefab, spawnPoints[i].position, spawnPoints[i].rotation);

            // Log a message
            Debug.Log("Respawned a book at " + spawnPoints[i].position);
        }
    }
}
