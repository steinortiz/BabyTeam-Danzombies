using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieBrain : MonoBehaviour
{
    public OrdaBeatReceiver fatherZone;
    public DancerSO _bodyAssets;
    [SerializeField] private DanceController _danceController;
    [SerializeField] private WalkController _walkController;
    
    private void OnEnable()
    {
        fatherZone.OnBeatZombieDance += SentToDanceController;
        fatherZone.OnBeatZombieWalk += SentToWalk;
        
    }

    private void OnDisable()
    {
        fatherZone.OnBeatZombieDance -= SentToDanceController;
        fatherZone.OnBeatZombieWalk -= SentToWalk;
    }

    public void Start()
    {
        _danceController.SetUp(_bodyAssets);
        _walkController.SetUp(_bodyAssets);
    }

    private void SentToDanceController(Moves moves)
    {
        if (BeatManager.Instance.simplifiedControllers)
        {
            _danceController.SetAllSprites(moves.simplyfied);
        }
        else
        {
            _danceController.SetHeadSprite(DanceMovesTypes.Default);
            _danceController.SetLeftArmSprite(moves.leftArm);
            _danceController.SetRightArmSprite(moves.rightArm);
        }
    }
    private void SentToWalk()
    {
        _walkController.DanceWalk();
    }
}
