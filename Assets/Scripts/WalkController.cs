using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkController : MonoBehaviour
{
    public bool doesNeedToWalk;
    public bool usePivot;
    private DancerSO fatherBodyAssets;

    [SerializeField] private SpriteRenderer legsGameObject;
    private int stepWalking;
    [SerializeField] private Transform pivot;
    [SerializeField] private List<Vector3> localPivotPost = new List<Vector3>();
    private int pivotWalking;



    public void SetUp(DancerSO bodyAssets)
    {
        fatherBodyAssets = bodyAssets;
    }

    public void DanceWalk()
    {
        if (doesNeedToWalk)
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
            MovePivot();
        }
    }

    private void MovePivot()
    {
        if (usePivot)
        {
            if (pivotWalking + 1 == localPivotPost.Count)
            {
                pivotWalking = 0;
            }
            else
            {
                pivotWalking += 1;
            }

            pivot.localPosition = localPivotPost[pivotWalking];
        }
    }
}
