using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class PivotsInfo
{
    public Vector3 armsPivotPosition;
    public Vector3 bodyPivotRotation;
}

public class WalkController : MonoBehaviour
{
    private DancerSO fatherBodyAssets;

    [SerializeField] private SpriteRenderer headGameObject;
    [SerializeField] private SpriteRenderer bodyGameObject;
    [SerializeField] private SpriteRenderer legsGameObject;
    private int stepWalking;
    
    [SerializeField] private Transform armsPivot;
    [SerializeField] private Transform bodyPivot;
    [SerializeField] private List<PivotsInfo> localPivotInfo = new List<PivotsInfo>();
    
    public void SetUp(DancerSO bodyAssets)
    {
        fatherBodyAssets = bodyAssets;
        bodyGameObject.sprite = bodyAssets.body;
        headGameObject.sprite = bodyAssets.head;
    }

    public void DanceWalk()
    {
        
        if (stepWalking + 1 == fatherBodyAssets.legs.Count)
        {
            stepWalking = 0;
        }
        else
        {
            stepWalking += 1;
        }
        
        legsGameObject.sprite = fatherBodyAssets.legs[stepWalking];
        MovePivots(stepWalking);
        
    }

    private void MovePivots(int stepWalk)
    {
        armsPivot.localPosition = localPivotInfo[stepWalk].armsPivotPosition;
        bodyPivot.Rotate(localPivotInfo[stepWalking].bodyPivotRotation);
    }
}
