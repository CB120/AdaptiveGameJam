﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    public ParticleSystem lavaBurst;
    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(0, 10);
        InvokeRepeating("SummonLava", random, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SummonLava()
    {
        float random = Random.Range(0, 100);
        print(random);
        if(random > 75)
        {
            lavaBurst.Play();
        }
    }
}
