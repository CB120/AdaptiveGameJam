using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCubes : MonoBehaviour
{
    SpawnGrid spawnGrid;
    bool hasHit = false;
    void Start()
    {
        GameObject gameManager = GameObject.FindGameObjectWithTag("GameController");
        spawnGrid = gameManager.GetComponent<SpawnGrid>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < 0 && hasHit == false && gameObject.tag == "Vacant")
        {
            print("Missed"); //Chris implement something here for health
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hasHit = true;
        }
    }
}
