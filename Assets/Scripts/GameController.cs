using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] private bool isPlaying;
    private bool isPaused;
    
    public delegate void PauseEvent(bool isPaused);
    public static event PauseEvent OnPauseEvent;
    public delegate void PlayEvent(bool isPlaying);
    public static event PlayEvent OnPlayEvent;
    
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

    public void PlayGame()
    {
        isPlaying = true;
        isPaused = false;
        if (OnPlayEvent != null)
        {
            OnPlayEvent(isPlaying);
        }
        OrdasSpawnerController.Instance?.SpawnOrda();
        
    }

    public void StopGame()
    {
        isPlaying = false;
        isPaused = false;
        if (OnPlayEvent != null)
        {
            OnPlayEvent(isPlaying);
        }
        OrdasSpawnerController.Instance?.SpawnOrda();
    }

    public void SetPauseGame(bool paused)
    {
        isPaused = paused;
        if (OnPauseEvent != null)
        {
            OnPauseEvent(isPaused);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.Pause)) && isPlaying)
        {
            if (!isPaused)
            {
                SetPauseGame(true);
            }
            else
            {
                //SetPauseGame(false);
            }
            
        }
    }
    
    
}
