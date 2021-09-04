using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCubes : MonoBehaviour
{
    PlayerManager playerManager;
    GamemodeManager gamemodeManager;

    // Start is called before the first frame update
    void Start()
    {
        GameObject manager = GameObject.FindGameObjectWithTag("GameController");
        playerManager = manager.GetComponent<PlayerManager>();
        gamemodeManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GamemodeManager>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            playerManager.gameOver = true;
            if(gamemodeManager.currentGameMode == GamemodeManager.GameMode.PerspectiveShift)
            {
                Destroy(gameObject);
            }
            //print("died");
        }
    }
}
