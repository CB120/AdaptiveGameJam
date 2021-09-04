using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCubes : MonoBehaviour
{
    SpawnGrid spawnGrid;
    ScoreManager scoreManager;
    bool hasHit = false;
    void Start()
    {
        GameObject gameManager = GameObject.FindGameObjectWithTag("GameController");
        spawnGrid = gameManager.GetComponent<SpawnGrid>();
        scoreManager = gameManager.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < 0 && hasHit == false && gameObject.tag == "Vacant")
        {
            print("Missed"); 
            scoreManager.DecreaseScore(20);


            hasHit = true;// End of script chris put your health stuff before here
        }
        
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
