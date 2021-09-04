using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamemodeManager : MonoBehaviour
{
    //Enumerator used to control the current game mode
    public enum GameMode {Adapt,  PerspectiveShift};
    public GameMode currentGameMode = GameMode.Adapt;
    PlayerManager PMScript;
    SpawnEnemy SpawnEnemyScript;
    SpawnGrid spawnGrid;

    //Variables used to control waves
    float timer = 0;
    [SerializeField] private float waveLength = 15;
    private int currentWave = 0;

    //References to UI
    //public Text timeDisplay;
    //public Text waveDisplay;
    //public Text modeDisplay;



    // Start is called before the first frame update
    void Start()
    {
        //Default game mode is Adapt
        PMScript = FindObjectOfType<PlayerManager>();
        SpawnEnemyScript = FindObjectOfType<SpawnEnemy>();
        currentGameMode = GameMode.Adapt;
        spawnGrid = FindObjectOfType<SpawnGrid>();
    }

    // Update is called once per frame
    void Update()
    {
        //Update the timer
        if(timer < waveLength)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
        }
        //If we reach the end of a wave
        else if(timer >= waveLength)
        {
            //Determine gamemode based on current wave
            if (currentWave % 2 == 0)
            {
                currentGameMode = GameMode.PerspectiveShift;
                
                SpawnEnemyScript.alternateGameMode = true;
                if (!PMScript.gameOver)
                {
                    for (int i = 0; i < SpawnEnemyScript.EnemyWall.Count; i++)
                    {
                        SpawnEnemyScript.EnemyWall[i].GetComponent<EnemyConnector>().getFucked = true;
                    }

                    for(int i = 0; i < spawnGrid.Buttons.Length; i++)
                    {
                        spawnGrid.Buttons[i].GetComponent<Image>().SetTransparency(0.2f);
                    }
                }
            }
            else
            {
                if (!PMScript.gameOver)
                {
                    for (int i = 0; i < SpawnEnemyScript.EnemyWall.Count; i++)
                    {
                        SpawnEnemyScript.EnemyWall[i].GetComponent<EnemyConnector>().getFucked = true;
                    }

                    for (int i = 0; i < spawnGrid.Buttons.Length; i++)
                    {
                        spawnGrid.Buttons[i].GetComponent<Image>().SetTransparency(0.2f);
                    }
                }
                currentGameMode = GameMode.Adapt;
                SpawnEnemyScript.alternateGameMode = false;
            }
            //Update our wave variables
            timer = 0;
            currentWave++;        
        }

        //Update the UI
/*        if (waveLength - timer <= 5)
        {
            timeDisplay.color = Color.red;
        }
        else
        {
            timeDisplay.color = Color.white;
        }

        timeDisplay.text = "Time Remaining: " + Mathf.Round((waveLength - timer));
        waveDisplay.text = "Current Wave: " + (currentWave + 1);
        if (currentGameMode == GameMode.Adapt)
        {
            modeDisplay.text = "Adapt!";
        }
        else if (currentGameMode == GameMode.PerspectiveShift)
        {
            modeDisplay.text = "Perspective Shift!";
        }*/
    }
}
