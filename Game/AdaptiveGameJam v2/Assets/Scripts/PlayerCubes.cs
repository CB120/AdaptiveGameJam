using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCubes : MonoBehaviour
{
    public CameraShake cameraShake;
    PlayerManager playerManager;
    public Material gridMaterial, transparentMaterial;
    public AudioSource audiosource;
    public AudioClip gridClick;
    public AudioClip UnclickGrid;

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
            gridPress();
        }
        if (Input.GetButtonUp("Transparent"))
        {
            gameObject.GetComponent<MeshRenderer>().material = gridMaterial;
            depressGrid();
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
            //StartCoroutine(cameraShake.Shake(.10f, .4f));
            //playerManager.gameOver = true;
            playerManager.Damaged();
            //print("died");
        }
    }

    void gridPress()
    {
        audiosource.clip = gridClick;
        audiosource.Play();
    }

    void depressGrid()
    {
        audiosource.clip = UnclickGrid;
        audiosource.Play();
    }
}
