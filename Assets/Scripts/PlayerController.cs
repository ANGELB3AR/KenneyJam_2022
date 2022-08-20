using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Dart minusDart;
    Dart plusDart;

    private void Awake()
    {
        minusDart = GameObject.FindGameObjectWithTag("MinusDart").GetComponent<Dart>();
        plusDart = GameObject.FindGameObjectWithTag("PlusDart").GetComponent<Dart>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            FireMinusDart();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            FirePlusDart();
        }
    }

    private void FirePlusDart()
    {
        plusDart.LaunchDart();
    }

    private void FireMinusDart()
    {
        minusDart.LaunchDart();
    }
}
