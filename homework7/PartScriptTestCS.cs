﻿using UnityEngine;
using System.Collections;

public class PartScriptTestCS : MonoBehaviour
{

    public float engineRevs;
    public float exhaustRate;

    ParticleSystem exhaust;


    void Start()
    {
        exhaust = GetComponent<ParticleSystem>();
    }


    void Update()
    {
        exhaust.emissionRate = engineRevs * exhaustRate;
    }

}