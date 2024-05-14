using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameTImer : MonoBehaviour
{
    public int maxRounds = 5;
    public float[] roundTimes = { 180f, 150f, 120f, 90f }; // Time for each round in seconds
    private float currentTime;
    private int currentRound = 0;

    public TextMeshProUGUI timerText;  // Assign in the Inspector
    public ScoreDisplay scoreDisplay; // Assign in the Inspector
    public GameObject gameOverScreen; // Assign in the Inspector
    public TextMeshProUGUI roundText; // Assign in the Inspector

    void Start()
    {
        StartNewRound();
    }

    void Update()
    {
        // Decrease the current time
        currentTime -= Time.deltaTime;

        // Update the timer text
        int minutes = Mathf.FloorToInt(currentTime / 60F);
        int seconds = Mathf.FloorToInt(currentTime - minutes * 60);
        timerText.text = string.Format("Time Remaining: {0:0}:{1:00}", minutes, seconds);

        // Check if the player has enough points to go to the next round
        if (GameManager.instance.score >= 6) // Access the score from GameManager
        {
            StartNewRound();
        }
        // Check if the time has run out
        else if (currentTime <= 0f)
        {
            // End the game
            gameOverScreen.SetActive(true);
        }
    }

    void StartNewRound()
    {
        if (currentRound < maxRounds)
        {
            currentRound++;
            currentTime = roundTimes[currentRound - 1]; // Set the time for the new round

            // Reset the score
            GameManager.instance.score = 0;

            // Update the round text
            roundText.text = "Round " + currentRound.ToString();

            // Respawn the books
            GetComponent<BookRespawner>().RespawnBooks();
        }
        else
        {
            // End the game
            gameOverScreen.SetActive(true);
        }
    }

}
