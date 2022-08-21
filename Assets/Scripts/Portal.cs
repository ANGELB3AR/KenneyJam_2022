using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] int nextLevel = -1;

    LevelManager levelManager;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Triggered collider");
            levelManager.LoadNextLevel(nextLevel);

            if (nextLevel < 0)
            {
                Debug.Log("You have not indicated the next level for this portal yet");
            }
        }
    }
}
