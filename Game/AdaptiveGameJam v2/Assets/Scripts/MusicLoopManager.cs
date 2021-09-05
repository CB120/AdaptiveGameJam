using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoopManager : MonoBehaviour
{
    //Properties
    [SerializeField] float loopStartTime; //time (in seconds) into the track that should be looped back to
    [SerializeField] float loopEndTime; //time (in seconds) into the track that the loop should be created


    //Variables
    GameObject oldPlayer, newPlayer;
    float trackLength;


    //References
    public GameObject musicPlayerPrefab;


    //Engine-called
    void Start(){
        DontDestroyOnLoad(gameObject);
        SetupLoop();
    }


    //Methods
    void SetupLoop(){
        newPlayer = Instantiate(musicPlayerPrefab, transform);
        trackLength = newPlayer.GetComponent<AudioSource>().clip.length;
        Invoke("LoopTrack", loopEndTime);
    }

    void LoopTrack(){
        oldPlayer = newPlayer;
        newPlayer = Instantiate(musicPlayerPrefab, transform);
        newPlayer.GetComponent<AudioSource>().time = loopStartTime;
        Invoke("DestroyOldPlayer", trackLength - loopEndTime);
        Invoke("LoopTrack", loopEndTime - loopStartTime);
    }

    void DestroyOldPlayer(){
        Destroy(oldPlayer);
    }
}
