using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private void Update()
    {
        scoreText.text = "Score: " + GameManager.instance.score;
    }
}
