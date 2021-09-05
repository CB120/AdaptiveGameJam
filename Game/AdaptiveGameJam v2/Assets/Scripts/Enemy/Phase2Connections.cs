using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase2Connections : MonoBehaviour
{
    public List<GameObject> ConnectedCubes;
    public bool getFucked = false;
    [SerializeField]

    private void Update()
    {
        if (getFucked)
            Destroy(this.gameObject);
    }
}
