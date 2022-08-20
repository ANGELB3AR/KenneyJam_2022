using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Dart minusDart;
    [SerializeField] Dart plusDart;

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
