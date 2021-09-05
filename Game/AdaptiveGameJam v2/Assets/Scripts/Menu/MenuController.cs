using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    //Properties


    //Variables


    //Hierarchy References
    [SerializeField] Text highScoreText;
    [SerializeField] GameObject[] creditsText;

    //Prefab References
    [SerializeField] GameObject musicManagerPrefab;


    //Engine-called
    void Start(){
        LoadHighScore();
        LoadMusic();
    }


    //UI-called
    public void PlayButton(){
        //Start camera animation?
        LoadLevel();
    }

    public void CreditsButton(){
        ShowCreditsText();
    }


    //Methods
    void LoadHighScore(){
        int bestScore = PlayerPrefs.GetInt("High_Score", 0);
        highScoreText.text = "Best: " + bestScore;
    }

    void LoadMusic(){
        if (!PersistentVariables.musicSpawned){
            Instantiate(musicManagerPrefab);
            PersistentVariables.musicSpawned = true;
        }
    }

    void LoadLevel(){
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    void ShowCreditsText(){
        foreach (GameObject g in creditsText){
            g.SetActive(!g.activeSelf);
        }
    }
}
