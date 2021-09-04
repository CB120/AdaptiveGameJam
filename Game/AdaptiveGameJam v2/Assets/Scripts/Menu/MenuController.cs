using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    //Properties


    //Variables


    //References
    [SerializeField] Text highScoreText;


    //Engine-called
    void Start(){
        LoadHighScore();
    }

    void Update(){

    }


    //UI-called
    public void PlayButton(){
        //Start camera animation?
        LoadLevel();
    }

    public void QuitButton(){

    }


    //Methods
    void LoadHighScore(){
        int bestScore = PlayerPrefs.GetInt("High_Score", 0);
        highScoreText.text = "Best: " + bestScore;
    }

    void LoadLevel(){
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
