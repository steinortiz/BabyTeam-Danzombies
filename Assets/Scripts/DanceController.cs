using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceController : MonoBehaviour
{
    private DancerSO fatherBodyAssets;
    [SerializeField] private SpriteRenderer leftArmGameObject;
    [SerializeField] private SpriteRenderer rightArmGameObject;
    
    private DanceMovesTypes headState;
    private DanceMovesTypes leftArmState;
    private DanceMovesTypes rightArmState;

    public void SetUp(DancerSO bodyAssets)
    {
        fatherBodyAssets = bodyAssets;
        ResetAllSprites();
    }
    
    public void SetLeftArmSprite(DanceMovesTypes danceMove)
    {
        if (leftArmState != danceMove && leftArmGameObject != null)
        {
            leftArmGameObject.sprite = fatherBodyAssets.leftArm.GetPostrue(danceMove);
            leftArmState = danceMove;
        }
    }
    
    public void SetRightArmSprite(DanceMovesTypes danceMove)
    {
        if (rightArmState != danceMove && rightArmGameObject != null)
        {
            rightArmGameObject.sprite = fatherBodyAssets.rightArm.GetPostrue(danceMove);
            rightArmState = danceMove;
        }
    }
    public void SetAllSprites(DanceMovesTypes danceMove)
    {
        
        leftArmGameObject.sprite = fatherBodyAssets.leftArm.GetPostrue(danceMove);
        leftArmState = danceMove;
        rightArmGameObject.sprite = fatherBodyAssets.rightArm.GetPostrue(danceMove);
        rightArmState = danceMove;
    }

    public void ResetAllSprites(DanceMovesTypes danceMove =DanceMovesTypes.Default)
    {
        leftArmGameObject.sprite = fatherBodyAssets.leftArm.GetPostrue(danceMove);
        leftArmState = danceMove;
        rightArmGameObject.sprite = fatherBodyAssets.rightArm.GetPostrue(danceMove);
        rightArmState = danceMove;
    }
}
