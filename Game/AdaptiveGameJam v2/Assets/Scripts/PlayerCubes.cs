using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCubes : MonoBehaviour
{
    PlayerManager playerManager;
    public Material gridMaterial, transparentMaterial;

    // Start is called before the first frame update
    
    void Start()
    {
       
        GameObject manager = GameObject.FindGameObjectWithTag("GameController");
        playerManager = manager.GetComponent<PlayerManager>();
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Transparent"))
        {
            gameObject.GetComponent<MeshRenderer>().material = transparentMaterial;
        }
        if (Input.GetButtonUp("Transparent"))
        {
            gameObject.GetComponent<MeshRenderer>().material = gridMaterial;
        }
        if (playerManager.gameOver)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            //playerManager.gameOver = true;
            playerManager.Damaged();
            //print("died");
        }
    }
}
