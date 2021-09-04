using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCubes : MonoBehaviour
{
    PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
       
        GameObject manager = GameObject.FindGameObjectWithTag("GameController");
        playerManager = manager.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            
            playerManager.gameOver = true;
            //print("died");
        }
    }
}
