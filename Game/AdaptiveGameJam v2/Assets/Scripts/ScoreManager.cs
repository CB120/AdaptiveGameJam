using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    int currentScore = 0;
    int previousHighScore;
    void Start()
    {
        currentScore = 0;
        previousHighScore = PlayerPrefs.GetInt("High_Score");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScore > previousHighScore)
        {
           // PlayerPrefs.SetInt("High_Score")
        }
    }

    void IncreaseScore(int scoreIncrease)
    {
        currentScore += scoreIncrease;
        scoreText.text = currentScore.ToString();
    }
}
