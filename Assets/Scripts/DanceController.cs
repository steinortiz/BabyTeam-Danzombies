using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DanceController : MonoBehaviour
{
    public DancerSO bodyAssets;
    [SerializeField] private SpriteRenderer headGameObject;
    [SerializeField] private SpriteRenderer leftArmGameObject;
    [SerializeField] private SpriteRenderer rightArmGameObject;
    
    private DanceMovesTypes headState;
    private DanceMovesTypes leftArmState;
    private DanceMovesTypes rightArmState;

    public void Start()
    {
        ResetDancer();
    }

    public void UpdateHeadSprite(DanceMovesTypes danceMove)
    {
        
        if (headState != danceMove)
        {
            headGameObject.sprite = bodyAssets.head.GetPostrue(danceMove);
            headState = danceMove;
        }
    }
    public void UpdateLeftArmSprite(DanceMovesTypes danceMove)
    {
        if (leftArmState != danceMove)
        {
            leftArmGameObject.sprite = bodyAssets.leftArm.GetPostrue(danceMove);
            leftArmState = danceMove;
        }
    }
    
    public void UpdateRightArmSprite(DanceMovesTypes danceMove)
    {
        if (rightArmState != danceMove)
        {
            rightArmGameObject.sprite = bodyAssets.rightArm.GetPostrue(danceMove);
            rightArmState = danceMove;
        }
    }
    public void SetDancer(DanceMovesTypes danceMove)
    {
        headGameObject.sprite = bodyAssets.head.GetPostrue(danceMove);
        headState = danceMove;
        leftArmGameObject.sprite = bodyAssets.leftArm.GetPostrue(danceMove);
        leftArmState = danceMove;
        rightArmGameObject.sprite = bodyAssets.rightArm.GetPostrue(danceMove);
        rightArmState = danceMove;
    }

    public void ResetDancer(DanceMovesTypes danceMove =DanceMovesTypes.Default)
    {
        headGameObject.sprite = bodyAssets.head.GetPostrue(danceMove);
        headState = danceMove;
        leftArmGameObject.sprite = bodyAssets.leftArm.GetPostrue(danceMove);
        leftArmState = danceMove;
        rightArmGameObject.sprite = bodyAssets.rightArm.GetPostrue(danceMove);
        rightArmState = danceMove;
    }
}
