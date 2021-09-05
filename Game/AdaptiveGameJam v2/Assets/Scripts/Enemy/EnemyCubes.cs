using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCubes : MonoBehaviour
{
    SpawnGrid spawnGrid;
    ScoreManager scoreManager;
    PlayerManager playerManager;
    bool hasHit = false, particlesPlayed = false;
    bool didMiss = false;

    public Material transparentMaterial, missedMaterial;

    GamemodeManager gamemodeManager;
    //private float duration = 300f;
    float t;
    ParticleSystem Particles;
    void Start()
    {
        gamemodeManager = FindObjectOfType<GamemodeManager>();
        GameObject gameManager = GameObject.FindGameObjectWithTag("GameController");
        spawnGrid = gameManager.GetComponent<SpawnGrid>();
        scoreManager = gameManager.GetComponent<ScoreManager>();
        playerManager = gameManager.GetComponent<PlayerManager>();
        Particles = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < 0 && hasHit == false && gameObject.tag == "Vacant")
        {
            // print("Missed");
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            didMiss = true;
            //gameObject.GetComponent<Image>().SetTransparency(0.4f);
            //gameObject.GetComponent<MeshRenderer>().material = missedMaterial;
            scoreManager.DecreaseScore(20);

            hasHit = true;// End of script chris put your health stuff before here
        }
        
        if(playerManager.gameOver && !particlesPlayed)
        {
            Invoke("PlayEffect", 1.0f);
            particlesPlayed = true;
        }


        if (transform.position.z < 0)
        {
            if (didMiss)
            {
                gameObject.GetComponent<MeshRenderer>().material = missedMaterial;
            }
            else
            {
                gameObject.GetComponent<MeshRenderer>().material = transparentMaterial;
            }
          
        }
       

    }

    void PlayEffect()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        Particles.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gamemodeManager.currentGameMode == GamemodeManager.GameMode.Adapt)
        {
            if (other.gameObject.tag == "Player")
            {
                hasHit = true;
                scoreManager.IncreaseScore(10);
            }
        }
        else if (gamemodeManager.currentGameMode == GamemodeManager.GameMode.PerspectiveShift)
        {
            if (other.gameObject.tag == "Player")
            {
                scoreManager.IncreaseScore(10);
                hasHit = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gamemodeManager.currentGameMode == GamemodeManager.GameMode.PerspectiveShift)
        {
            if (collision.gameObject.tag == "Player")
            {
                playerManager.Damaged();
            }
        }
    }
}
