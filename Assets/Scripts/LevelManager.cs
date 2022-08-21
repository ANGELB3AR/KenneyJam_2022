using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int firstLevel = 1;
    [SerializeField] float levelResetTime = 1.5f;
    [SerializeField] float nextLevelLoadTime = 1.5f;

    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        int instanceCount = FindObjectsOfType(GetType()).Length;

        if (instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetCurrentLevel()
    {
        StartCoroutine(ResetLevelRoutine());
    }

    public void LoadNextLevel(int levelToLoad)
    {
        StartCoroutine(LoadNextLevelRoutine(levelToLoad));
    }

    public void StartGame()
    {
        SceneManager.LoadScene(firstLevel);
    }

    IEnumerator ResetLevelRoutine()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        yield return new WaitForSeconds(levelResetTime);
        SceneManager.LoadScene(currentLevel);
    }

    IEnumerator LoadNextLevelRoutine(int level)
    {
        yield return new WaitForSeconds(nextLevelLoadTime);
        SceneManager.LoadScene(level);
    }
}
