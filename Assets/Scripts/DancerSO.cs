using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DanzablePart
{
    public Sprite normalPosture;
    public Sprite upPosture;
    public Sprite downPosture;
    public Sprite leftPosture;
    public Sprite rightPosture;

    public Sprite GetPostrue(DanceMovesTypes dancePosture = DanceMovesTypes.Default)
    {
        if (dancePosture == DanceMovesTypes.Up)
        {
            return upPosture;
        }
        else if (dancePosture == DanceMovesTypes.Down)
        {
            return downPosture;
        }
        else if (dancePosture == DanceMovesTypes.Left)
        {
            return leftPosture;
        }
        else if (dancePosture == DanceMovesTypes.Right)
        {
            return rightPosture;
        }
        else
        {
            return normalPosture;
        }
    }
}


[CreateAssetMenu(fileName = "NewDancer", menuName = "ScriptableObjects/Dancer Postures", order = 1)]
public class DancerSO : ScriptableObject
{
    public Sprite head;
    public Sprite body;
    public DanzablePart leftArm = new DanzablePart();
    public DanzablePart rightArm = new DanzablePart();
    public List<Sprite> legs = new List<Sprite>(4);
}
