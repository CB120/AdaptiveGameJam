using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConnector : MonoBehaviour
{
    public List<GameObject> ConnectedCubes;
    public int AmtToPass = 0;
    [SerializeField]
    private float moveSpeed = 10;

    public bool getFucked = false;
    public GamemodeManager GameMode;

    private void Start()
    {
        GameMode = GameObject.FindWithTag("GameController").GetComponent<GamemodeManager>();
        moveSpeed += GameMode.waveNumber + Time.deltaTime;  // divide by point count or something
    }

    private void Update()
    { 
        transform.position = new Vector3(transform.position.x, transform.position.y, (transform.position.z - (moveSpeed * Time.deltaTime)));

        if (transform.position.z <= -10 || getFucked)
            Destroy(this.gameObject);
    }

}
