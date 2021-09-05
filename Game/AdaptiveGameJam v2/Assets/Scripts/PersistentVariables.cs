using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentVariables : MonoBehaviour
{
    //Static Variables
    public static bool musicSpawned = false; //used by MenuController to determine if a new MusicManager needs to be spawned. False = first time menu is shown, spawn MusicManager


    //Engine-called
    void Start(){
        DontDestroyOnLoad(this);
    }
}
