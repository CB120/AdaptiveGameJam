﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    UIManager uiManager;


    public bool gameOver = false; // Called in PlayerCubes.cs
    bool resetTime = false;
    int Health = 3;
    ScoreManager scoreManager;
    void Start()
    {
        GameObject gameManager = GameObject.FindGameObjectWithTag("GameController");
        uiManager = gameManager.GetComponent<UIManager>();
        scoreManager = gameManager.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver) //RESTART THE GAME
        {
            scoreManager.GameEnd();
            if (!resetTime)
            {

                //Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
                Time.timeScale = 0.2f;
                Invoke("ResetTime", 0.5f);
                resetTime = true;
            }
            
            //gameOver = false;
        }
    }

    void ResetTime()
    {
        Time.timeScale = 1.0f;
    }


    public void Damaged()
    {
        if (Health > 0)
        {
            Health = Health - 1;
            
            if (Health == 2)
            {
                uiManager.lifeImage.sprite = uiManager.lifeSprites[0];
            }
           
            if (Health == 1)
            {
                uiManager.lifeImage.sprite = uiManager.lifeSprites[1];
            }

            if (Health == 0)
            {
                uiManager.lifeImage.sprite = uiManager.lifeSprites[2];
            }

        }
        else if (Health == 0)
        {
            gameOver = true;
        }
        Debug.Log("Health = " + Health);
    }
 
}
