using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieBrain : MonoBehaviour
{
    public OrdaBeatReceiver fatherZone;
    [SerializeField] private DanceController _danceController;
    private void OnEnable()
    {
        fatherZone.OnBeatZombieDance += SentToDanceController;
    }

    private void OnDisable()
    {
        fatherZone.OnBeatZombieDance -= SentToDanceController;
    }

    private void SentToDanceController(Moves moves)
    {
        if (BeatManager.Instance.simplifiedControllers)
        {
            _danceController.SetDancer(moves.simplyfied);
        }
        else
        {
            _danceController.UpdateHeadSprite(DanceMovesTypes.Default);
            _danceController.UpdateLeftArmSprite(moves.leftArm);
            _danceController.UpdateRightArmSprite(moves.rightArm);
        }
    }
}
