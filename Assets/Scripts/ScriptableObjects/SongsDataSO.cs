using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DificultyOnSong
{
    Easy,
    Medium,
    Hard,
}
[Serializable]
public class SongPart
{
    public DificultyOnSong dificult;
    public float duration;
    public bool durateUntilTheSongEnd;

    public SongPart()
    {
        dificult = DificultyOnSong.Easy;
        durateUntilTheSongEnd = false;
        duration = 0f;
    }
}
[CreateAssetMenu(fileName = "New Song", menuName = "Danzombies/Song Data", order = 1)]
public class SongsDataSO : ScriptableObject
{
    public AudioClip song;
    public int bpm;
    [SerializeField] public List<SongPart> songParts = new List<SongPart>();

    public SongPart TryGetSongPart(int currentPart)
    {
        if (songParts.Count == 0 || songParts == null)
        {
            SongPart defaultPart = new SongPart();
            defaultPart.durateUntilTheSongEnd = true;
            return defaultPart;
        }
        else
        {
            return songParts[currentPart];
        }
    }
}
