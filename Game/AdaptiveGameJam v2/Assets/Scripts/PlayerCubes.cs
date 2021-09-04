using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCubes : MonoBehaviour
{
    PlayerManager playerManager;
    ParticleSystem Particles;
    // Start is called before the first frame update
    void Start()
    {
        Particles = GetComponentInChildren<ParticleSystem>();
        GameObject manager = GameObject.FindGameObjectWithTag("GameController");
        playerManager = manager.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Particles.Play();
            //playerManager.gameOver = true;
            playerManager.Damaged();
            //print("died");
        }
    }
}
