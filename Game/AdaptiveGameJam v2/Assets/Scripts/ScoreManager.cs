using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip PassCube;
    //public AudioClip highScore;
    public Text scoreText;
    int currentScore = 0;
    int previousHighScore;

   // bool hasHitZeroTwice = false;
    PlayerManager playerManager;
    void Start()
    {
        // currentScore = 0;
        previousHighScore = PlayerPrefs.GetInt("High_Score", 0);
        playerManager = FindObjectOfType<PlayerManager>();
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
        if (!playerManager.gameOver)
        {
            scoreText.color = new Color(255, 255f, 255f);

            currentScore += scoreIncrease;
            scoreText.text = currentScore.ToString();
            passCube();
        }

        
    }

    public void DecreaseScore(int scoreDecrease)
    {
        if (!playerManager.gameOver)
        {
            scoreText.color = new Color(255, 0f, 0f);


            if (currentScore - scoreDecrease > 0)
            {
                currentScore -= scoreDecrease;
                scoreText.text = currentScore.ToString();
            }
            else
            {
                playerManager.gameOver = true; // If the player hits 0 after the game starts they die
                currentScore = 0;
                scoreText.text = currentScore.ToString();
            }
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

    void passCube()
    {
        audiosource.clip = PassCube;
        audiosource.Play();
    }
    /*
    void HighScore()
    {
        audiosource.clip = highScore;
        audiosource.Play();
    } */
}
