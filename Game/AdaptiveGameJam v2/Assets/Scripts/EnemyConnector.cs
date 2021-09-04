using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConnector : MonoBehaviour
{
    public List<GameObject> ConnectedCubes;
    public int AmtToPass = 0;
    [SerializeField]
    private float moveSpeed = 10;

    public float passedThroughTime;

    private void Update()
    { 
        //moveSpeed += passedThroughTime / 100.0f;  // divide by point count or something
        transform.position = new Vector3(transform.position.x, transform.position.y, (transform.position.z - (moveSpeed * Time.deltaTime)));

        if (transform.position.z <= -10)
            Destroy(this.gameObject);
    }

}
