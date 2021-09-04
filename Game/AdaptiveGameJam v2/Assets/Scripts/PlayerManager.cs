using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{ 
    public bool gameOver = false; // Called in PlayerCubes.cs
    bool resetTime = false;
    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver) //RESTART THE GAME
        {
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
}
