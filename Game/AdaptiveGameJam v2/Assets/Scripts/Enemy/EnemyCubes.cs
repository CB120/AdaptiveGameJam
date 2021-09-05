using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCubes : MonoBehaviour
{
    SpawnGrid spawnGrid;
    ScoreManager scoreManager;
    PlayerManager playerManager;
    bool hasHit = false, particlesPlayed = false;

    public Material transparentMaterial;

    //private float duration = 300f;
    float t;
    ParticleSystem Particles;
    void Start()
    {
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
           gameObject.GetComponent<MeshRenderer>().material = transparentMaterial;
        }
       

    }

    void PlayEffect()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        Particles.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hasHit = true;
            scoreManager.IncreaseScore(10);
        }
    }
}
