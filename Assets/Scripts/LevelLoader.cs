using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu")
        {
            GameController.Instance.StopGame();
        }
        else
        {
            GameController.Instance.PlayGame();
        }
    }

    public void LoadGame(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void LoadMainMenu()
    {
        // cortina
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
