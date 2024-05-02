using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;



public class PlayerController : MonoBehaviour
{
    public DanceController body;
    public SpriteRenderer piso;
    [SerializeField] private Color activeColor;
    [SerializeField] private Color unsactiveColor;
    private bool isOnZombieZone = false;
    private OrdaBeatReceiver zombieZone;
    
    

    // Update is called once per frame
    void Update()
    {
        if (BeatManager.Instance.simplifiedControllers)
        {
            if (Input.GetKeyDown("up"))
            {
                SendDanceMove(DanceMovesTypes.Up);
                body.SetDancer(DanceMovesTypes.Up);
                piso.color = activeColor;
            }
            else if(Input.GetKeyUp("up"))
            {
                body.ResetDancer();
                piso.color = unsactiveColor;
            }
            
            if (Input.GetKeyDown("down"))
            {
                SendDanceMove(DanceMovesTypes.Down);
                body.SetDancer(DanceMovesTypes.Down);
                piso.color = activeColor;
            }
            else if(Input.GetKeyUp("down"))
            {
                body.ResetDancer();
                piso.color = unsactiveColor;
            }
            
            if (Input.GetKeyDown("left"))
            {
                SendDanceMove(DanceMovesTypes.Left);
                body.SetDancer(DanceMovesTypes.Left);
                piso.color = activeColor;
            }
            else if(Input.GetKeyUp("left"))
            {
                body.ResetDancer();
                piso.color = unsactiveColor;
            }
            
            if (Input.GetKeyDown("right"))
            {
                SendDanceMove(DanceMovesTypes.Right);
                body.SetDancer(DanceMovesTypes.Right);
                piso.color = activeColor;
            }
            else if(Input.GetKeyUp("right"))
            {
                body.ResetDancer();
                piso.color = unsactiveColor;
            }
        }
    }

    private void OnTriggerEnter(Collider otherObj)
    {
        zombieZone = otherObj.transform.GetComponent<OrdaBeatReceiver>();
        zombieZone.playerInOrda = true;
        isOnZombieZone = true;
    }

    private void OnTriggerExit(Collider otherObj)
    {
        isOnZombieZone = false;
        zombieZone.playerInOrda = false;
        zombieZone = null;
    }

    private void SendDanceMove(DanceMovesTypes move)
    {
        if (isOnZombieZone)
        {
            zombieZone.RecievePlayerDance(move);
        }
    }
}
