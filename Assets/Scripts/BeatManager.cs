using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BeatType
{
    Corchea,
    Negra,
    Blanca,
    Redonda
}

public class BeatManager : MonoBehaviour
{
    public static BeatManager Instance { get; private set; }

    public delegate void OnBeatEvent(BeatType type);
    public static event OnBeatEvent OnBeat;

    //[SerializeField] public static bool isPlaying {  get; private set; }
    public bool isPlaying;

    public float bpm;
    private float timer;
    private int counter;
    private int totalcounter;
    
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this;
            DontDestroyOnLoad(this);
        } 
    }

    private void Start()
    {
        isPlaying = false;
        timer = 0f;
    }
    
    void Update()
    {
        if (isPlaying)
        {
            timer += Time.deltaTime;
            if (timer >= 60/bpm)
            {
                timer = 0;
                Beat();
            }
        }
    }

    void Beat()
    {
        counter += 1;
        OnBeat(BeatType.Corchea);
        if (counter%2==0)
        {
            OnBeat(BeatType.Negra);
        }
        if (counter%4==0)
        {
            OnBeat(BeatType.Blanca);
        }
         if (counter%8 == 0)
        {
            OnBeat(BeatType.Redonda);
        }
    }

    public void PlayBeat()
    {
        isPlaying = true;
    }
}
