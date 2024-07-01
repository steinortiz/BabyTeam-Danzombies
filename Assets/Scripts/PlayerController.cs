using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;



public class PlayerController : MonoBehaviour
{
    public DanceController body;
    public DancerSO _bodyAssets;
    public SpriteRenderer piso;
    [SerializeField] private Color activeColor;
    [SerializeField] private Color unsactiveColor;
    private bool isOnZombieZone = false;
    private OrdaBeatReceiver zombieZone;
    private bool Press;
    private bool rightPress;
    private bool simpliPress;


    private void Start()
    {
        body.SetUp(_bodyAssets);
    }

    void Update()
    {
        bool simplyfied = true;
        if(BeatManager.Instance != null)simplyfied = BeatManager.Instance.simplifiedControllers;
        if (simplyfied)
        {
            if (Input.GetKeyDown("up"))
            {
                SendDanceMove(DanceMovesTypes.Up);
                body.SetAllSprites(DanceMovesTypes.Up);
                piso.color = activeColor;
            }
            else if(Input.GetKeyUp("up"))
            {
                body.ResetAllSprites();
                piso.color = unsactiveColor;
            }
            
            if (Input.GetKeyDown("down"))
            {
                SendDanceMove(DanceMovesTypes.Down);
                body.SetAllSprites(DanceMovesTypes.Down);
                piso.color = activeColor;
            }
            else if(Input.GetKeyUp("down"))
            {
                body.ResetAllSprites();
                piso.color = unsactiveColor;
            }
            
            if (Input.GetKeyDown("left"))
            {
                SendDanceMove(DanceMovesTypes.Left);
                body.SetAllSprites(DanceMovesTypes.Left);
                piso.color = activeColor;
            }
            else if(Input.GetKeyUp("left"))
            {
                body.ResetAllSprites();
                piso.color = unsactiveColor;
            }
            
            if (Input.GetKeyDown("right"))
            {
                SendDanceMove(DanceMovesTypes.Right);
                body.SetAllSprites(DanceMovesTypes.Right);
                piso.color = activeColor;
            }
            else if(Input.GetKeyUp("right"))
            {
                body.ResetAllSprites();
                piso.color = unsactiveColor;
            }
        }
        else
        {
            float h_left = Input.GetAxis("Horizontal2");
            float v_left = Input.GetAxis("Vertical2");
            float h_right = Input.GetAxis("Horizontal2");
            float v_right = Input.GetAxis("Vertical2");
            // input unsimplified
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
