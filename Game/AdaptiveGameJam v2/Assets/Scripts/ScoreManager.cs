using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    int currentScore = 0;
    int previousHighScore;
    float speed = 1.0f; //how fast it shakes
    float amount = 1.0f; //how much it shakes
    void Start()
    {
        // currentScore = 0;
        previousHighScore = PlayerPrefs.GetInt("High_Score", 0);
    }

    private void Update()
    {
        if(currentScore > previousHighScore)
        {
            scoreText.color = new Color(0, 255f, 0);
        }
    }

    public void IncreaseScore(int scoreIncrease)
    {
        scoreText.color = new Color(255, 255f, 255f);
        
        currentScore += scoreIncrease;
        scoreText.text = currentScore.ToString();
    }

    public void DecreaseScore(int scoreDecrease)
    {
        scoreText.color = new Color(255, 0f, 0f);

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
}
