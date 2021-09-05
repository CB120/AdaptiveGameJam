using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCubes : MonoBehaviour
{
    public CameraShake cameraShake;
    PlayerManager playerManager;
    public Material gridMaterial, transparentMaterial;
    

    // Start is called before the first frame update
    
    void Start()
    {
       
        //GameObject manager = GameObject.FindGameObjectWithTag("GameController");
        //playerManager = manager.GetComponent<PlayerManager>();
        
    }

    private void Update()
    {
<<<<<<< Updated upstream
        
=======
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
>>>>>>> Stashed changes
    }

   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //StartCoroutine(cameraShake.Shake(.10f, .4f));
            //playerManager.gameOver = true;
            Destroy(gameObject);
            playerManager.Damaged();
            //print("died");
        }
    }
<<<<<<< Updated upstream

    
=======
>>>>>>> Stashed changes
}
