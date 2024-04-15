using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Image body;
    
    //simplified Arms
    public bool simplifiedControllers;
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
    
    // Start is called before the first frame update
    void Start()
    {
     body.color = Color.white;   
    }

    // Update is called once per frame
    void Update()
    {
        if (simplifiedControllers)
        {
            if (Input.GetKey("up"))
            {
                //debug
                body.color = Color.blue;
            }
            else if (Input.GetKey("down"))
            {
                //debug
                body.color = Color.red;
            }
            else if (Input.GetKey("left"))
            {
                body.color = Color.green;
            }
            else if (Input.GetKey("right"))
            {
                body.color = Color.yellow;
            }
            else
            {
                body.color= Color.white;
            }
            
        }
        
    }
}
