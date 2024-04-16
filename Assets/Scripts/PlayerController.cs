using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum DanceMovesTypes
{
    Default,
    Up,
    Left,
    Right,
    Down,
}

public class PlayerController : MonoBehaviour
{
    public Image body;
    
    //simplified Arms
    public bool armsLeftActive;
    public bool armsRightActive;
    public bool armsUpActive;
    public bool armsDownActive;
    
    //Left Arm
    public bool leftArmLeftActive;
    public bool leftArmRightActive;
    public bool leftArmUpActive;
    public bool leftArmDownActive;
    //Right Arm
    public bool rightArmLeftActive;
    public bool rightArmRightActive;
    public bool rightArmUpActive;
    public bool rightArmDownActive;

    public OrdaBeatReceiver other;
    public bool hasOther = false;

    // Start is called before the first frame update
    void Start()
    {
     body.color = Color.white;   
    }

    // Update is called once per frame
    void Update()
    {
        if (BeatManager.Instance.simplifiedControllers)
        {
            if (Input.GetKey("up"))
            {
                //debug
                body.color = Color.blue;
                SendDanceMove(DanceMovesTypes.Up);
            }
            else if (Input.GetKey("down"))
            {
                //debug
                body.color = Color.red;
                SendDanceMove(DanceMovesTypes.Down);
            }
            else if (Input.GetKey("left"))
            {
                body.color = Color.green;
                SendDanceMove(DanceMovesTypes.Left);
            }
            else if (Input.GetKey("right"))
            {
                body.color = Color.yellow;
                SendDanceMove(DanceMovesTypes.Right);
            }
            else
            {
                body.color= Color.white;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D otherObj)
    {
        other = otherObj.transform.GetComponent<OrdaBeatReceiver>();
        other.playerInOrda = true;
        hasOther = true;
    }

    private void OnTriggerExit2D(Collider2D otherObj)
    {
        hasOther = false;
        other.playerInOrda = false;
        other = null;
    }
    

    private void SendDanceMove(DanceMovesTypes move)
    {
        if (hasOther)
        {
            other.RecievePlayerDance(move);
        }
    }
}
