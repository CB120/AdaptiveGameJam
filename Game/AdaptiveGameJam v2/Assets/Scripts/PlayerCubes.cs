using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCubes : MonoBehaviour
{
    SpawnGrid spawnGrid;
    void Start()
    {
        GameObject gameManager = GameObject.FindGameObjectWithTag("GameController");
        spawnGrid = gameManager.GetComponent<SpawnGrid>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Vacant")
        {
          //  spawnGrid.checkPlayerCollisions(1);
        }
    }
}
