using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private bool isPlaying;
    private bool isPaused;
    
    public delegate void PauseEvent(bool isPaused);
    public static event PauseEvent OnPauseEvent;
    
    public static GameController Instance { get; private set; }

    private void Awake() 
    {

        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } 
    }
    
    private void Start()
    {
        PlayGame();
    }

    private void PlayGame()
    {
        isPlaying = true;
        isPaused = false;
        BeatManager.Instance.PlaySong();
        OrdasSpawnerController.Instance.SpawnOrda();
    }

    public void PauseGame()
    {
        isPaused = true;
        if (OnPauseEvent != null)
        {
            OnPauseEvent(isPaused);
        }
        BeatManager.Instance.PauseSong();
        UiController.Instance.PauseUI();
    }
    public void UnPauseGame()
    {
        isPaused = false;
        if (OnPauseEvent != null)
        {
            OnPauseEvent(isPaused);
        }
        BeatManager.Instance.ResumeSong();
        UiController.Instance.UnPauseUI();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.Pause)) && isPlaying)
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                UnPauseGame();
            }
            
        }
    }
}
