using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum DanceMovesTypes
{
    Default,
    Up,
    Down,
    Left,
    Right,
}

[Serializable]
public class Moves
{
    [Header("On Simplified Version")]
    public DanceMovesTypes simplyfied = DanceMovesTypes.Default;
    
    [Header("On Unsimplified Version")]
    public DanceMovesTypes leftArm= DanceMovesTypes.Default;
    public DanceMovesTypes rightArm = DanceMovesTypes.Default;
}

[CreateAssetMenu(fileName = "NewDanceMoves", menuName = "Danzombies/Coreography", order = 1)]
public class CoreographySO : ScriptableObject
{
    public DificultyOnSong dificulty;
    public List<Moves> coreography = new List<Moves>();
}
