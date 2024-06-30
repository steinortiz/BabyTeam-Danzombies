using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum BeatType
{
    Corchea,
    Negra,
    Blanca,
    Redonda
}


public class BeatManager : MonoBehaviour
{
    
    public bool simplifiedControllers;
    public AudioSource _audioSource;

    public delegate void OnBeatEvent(BeatType type);
    public static event OnBeatEvent OnPreBeat;
    public static event OnBeatEvent OnBeat;
    public static event OnBeatEvent OnPostBeat;
    
    
    [Range(0f, 1f)] public float margen;
    public bool onMargen;

    public SongsDataSO songData {get; private set;}
    public DificultyOnSong currentDificulty{get; private set;}
    [SerializeField] private List<SongsDataSO> allSongs = new List<SongsDataSO>();

    public float bpmDuration { get; private set; }
    private float timer;
    private int counter;
    private int totalcounter;
    
    
    //auxiliares
    private bool canPre;
    private bool canBeat;
    private bool canPost;
    
    public static BeatManager Instance { get; private set; }
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this.gameObject); 
        } 
        else 
        { 
            Instance = this;
            //DontDestroyOnLoad(this);
        } 
    }

    private void Start()
    {
        //isPlaying = false;
        _audioSource = this.GetComponent<AudioSource>();
        
    }

    private void SetUpSong()
    {
        
    }
    
    void Update()
    {
        if (_audioSource.isPlaying)
        {
            float songTime = _audioSource.time;
            
            if (songTime >= ((bpmDuration * counter) - bpmDuration * margen)&& canPre)
            {
                canPre = false;
                PreBeat();
                canBeat = true;
            }
            else if (songTime >= bpmDuration * counter && canBeat)
            {
                canBeat = false;
                timer = songTime;
                Beat();
                canPost = true;
            }
            
            else if (songTime >= ((bpmDuration * counter) + bpmDuration * margen) && canPost)
            {
                canPost = false;
                PostBeat();
                canPre = true;
            }
        }
    }

    
    void PreBeat()
    {
        onMargen = true;
        if (OnPreBeat != null)
        {
            OnPreBeat(BeatType.Corchea);
            if (counter%2==0)
            {
                OnPreBeat(BeatType.Negra);
                if (counter%4==0)
                {
                    OnPreBeat(BeatType.Blanca);
                    if (counter%8 == 0)
                    {
                        OnPreBeat(BeatType.Redonda);
                    }
                }
            }
            
        }
        
    }
    void Beat()
    {
        
        if (OnBeat != null)
        {
            OnBeat(BeatType.Corchea);
            if (counter%2==0)
            {
                OnBeat(BeatType.Negra);
                if (counter%4==0)
                {
                    OnBeat(BeatType.Blanca);
                    if (counter%8 == 0)
                    {
                        OnBeat(BeatType.Redonda);
                    }
                }
            }
            
            
        }
        
    }
    void PostBeat()
    {
        onMargen = false;
        counter += 1;
        if (OnPostBeat != null)
        {
            OnPostBeat(BeatType.Corchea);
            if (counter%2==0)
            {
                OnPostBeat(BeatType.Negra);
                if (counter%4==0)
                {
                    OnPostBeat(BeatType.Blanca);
                    if (counter%8 == 0)
                    {
                        OnPostBeat(BeatType.Redonda);
                    }
                }
            }
            
            
        }
        
    }

    public void PlaySong()
    {
        onMargen = false;
        canPre = false;
        canBeat = true;
        canPost = false;
        songData = GetRandomSong();
        _audioSource.clip = songData.song;
        bpmDuration = (60f / songData.bpm);
        timer = bpmDuration;
        _audioSource.Play();
    }

    public SongsDataSO GetRandomSong()
    {
        return allSongs[Random.Range(0, allSongs.Count)];
    }


    public void PauseSong()
    {
        _audioSource.Pause();
    }
    public void ResumeSong()
    {
        _audioSource.Play();
    }
}
