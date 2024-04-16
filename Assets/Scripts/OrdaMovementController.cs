using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdaMovementController : MonoBehaviour
{
    public float Time;
    public Vector3 finalPos;
    public bool mustMovebytrigger;

    private void Update()
    {
        if (mustMovebytrigger)
        {
            Move();
            mustMovebytrigger = false;
        }
    }

    void Move()
    {
        LeanTween.moveLocal(this.gameObject, finalPos, Time).setDestroyOnComplete(true);
    }
}
