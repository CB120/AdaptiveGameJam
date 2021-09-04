using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{ 
    public bool gameOver = false; // Called in PlayerCubes.cs
    bool resetTime = false;
    float Health = 3;
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


    public void Damaged()
    {
        if (Health > 0)
        {
            Health = Health - 1;
        }
        else if (Health == 0)
        {
            gameOver = true;
        }
        Debug.Log("Health = " + Health);
    }
 
}
