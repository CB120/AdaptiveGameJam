using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamemodeManager : MonoBehaviour
{
    //Enumerator used to control the current game mode
    public enum GameMode {Adapt,  PerspectiveShift};
    public GameMode currentGameMode = GameMode.Adapt;

    //Variables used to control waves
    float timer = 0;
    [SerializeField] private float waveLength = 30;
    private int currentWave = 0;

    //References to UI
    public Text timeDisplay;
    public Text waveDisplay;
    public Text modeDisplay;



    // Start is called before the first frame update
    void Start()
    {
        //Default game mode is Adapt
        currentGameMode = GameMode.Adapt;
    }

    // Update is called once per frame
    void Update()
    {
        //Update the timer
        if(timer < waveLength)
        {
            timer += Time.deltaTime;
        }
        //If we reach the end of a wave
        else if(timer >= waveLength)
        {
            //Update our wave variables
            timer = 0;
            currentWave++;

            //Determine gamemode based on current wave
            if(currentWave % 2 == 0)
            {
                currentGameMode = GameMode.PerspectiveShift;
            }
            else
            {
                currentGameMode = GameMode.Adapt;
            }
            
        }

        //Update the UI
        timeDisplay.text = "Time Remaining: " + Mathf.Round((waveLength - timer));
        waveDisplay.text = "Current Wave: " + currentWave;
        if(currentGameMode == GameMode.Adapt)
        {
            modeDisplay.text = "Adapt!";
        }
        else if(currentGameMode == GameMode.PerspectiveShift)
        {
            modeDisplay.text = "Perspective Shift!";
        }
    }

    void Adapt()
    {

    }

    void PerspectiveShift()
    {

    }
}
