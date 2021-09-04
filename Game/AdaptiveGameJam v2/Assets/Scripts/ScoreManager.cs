using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip PassCube;
    public Text scoreText;
    int currentScore = 0;
    int previousHighScore;
    void Start()
    {
        // currentScore = 0;
        previousHighScore = PlayerPrefs.GetInt("High_Score", 0);
    }

    public void IncreaseScore(int scoreIncrease)
    {
        currentScore += scoreIncrease;
        scoreText.text = currentScore.ToString();
        playClip();
    }

    public void DecreaseScore(int scoreDecrease)
    {
        if (currentScore - scoreDecrease > 0)
        {
            currentScore -= scoreDecrease;
            scoreText.text = currentScore.ToString();
        }
        else
        {
            currentScore = 0;
            scoreText.text = currentScore.ToString();
        }
    }

    public void GameEnd()
    {
        if (currentScore > previousHighScore)
        {
            scoreText.color = new Color(255, 0f, 0f);
            PlayerPrefs.SetInt("High_Score", currentScore);
        }
    }

    void playClip()
    {
        audiosource.clip = PassCube;
        audiosource.Play();
    }
}
