using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    LevelManager levelManager;
    Dart minusDart;
    Dart plusDart;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();

        minusDart = GameObject.FindGameObjectWithTag("MinusDart").GetComponent<Dart>();
        plusDart = GameObject.FindGameObjectWithTag("PlusDart").GetComponent<Dart>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            minusDart.ResetDart();
            FireMinusDart();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            plusDart.ResetDart();
            FirePlusDart();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            levelManager.QuitGame();
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
