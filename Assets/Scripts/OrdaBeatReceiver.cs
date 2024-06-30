using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;



public class OrdaBeatReceiver : MonoBehaviour
{
    
    public BeatType danceBeatType;
    public BeatType walkBeatType;
    private LTDescr walkingTween;
    
    public SpriteRenderer piso;
    public List<Color> pisoColor = new List<Color>();
    private int colorIndex =-1;
    
    // Zmbies DanceList
    public bool generateRandomDance;
    public List<Moves> coreography = new List<Moves>();
    private int indexDanceMove=-1;
    public bool isRecieving;
    public delegate void BeatZombieDanceEvent(Moves zombiedance);
    public event BeatZombieDanceEvent OnBeatZombieDance;
    public delegate void BeatZombieWalkEvent();
    public event BeatZombieWalkEvent OnBeatZombieWalk;
    
    // Zombies Values
    public List<Transform> zombiesPos = new List<Transform>();
    

    //playerValues

    public bool playerInOrda;
    private DanceMovesTypes playerLeftMoveDone;
    private DanceMovesTypes playerRightMoveDone;
    //public bool isDanceCorrect;
    
    

    private void Start()
    {
        /*foreach (ZombieDanceController zombie in ZombiesGameObjects)
        {
            /// Spawn zombies, con variaciones.
            /// Put zombies in random positions.
            //zombie.Prepare(this) para que se suscriban al evento
        }*/
    }

    private void OnEnable()
    {
        BeatManager.OnBeat += OnBeatEvent;
        BeatManager.OnPreBeat += OnPreBeatEvent;
        BeatManager.OnPostBeat += OnPostBeatEvent;
        GameController.OnPauseEvent += OnPauseEventReceiver;
    }

    private void OnDisable()
    {
        BeatManager.OnBeat -= OnBeatEvent;
        BeatManager.OnPreBeat -= OnPreBeatEvent;
        BeatManager.OnPostBeat -= OnPostBeatEvent;
        GameController.OnPauseEvent -= OnPauseEventReceiver;
    }

    
    //Event Reactions
    private void OnPreBeatEvent(BeatType type)
    {
        if (type == danceBeatType)
        {
            PreBeatAction();
        }
        
    }
    
    private void OnBeatEvent(BeatType type)
    {
        if (type == danceBeatType)
        {
            BeatAction();
        }
        if (type == walkBeatType)
        {
            OnBeatZombieWalk();
        }
    }

    private void OnPostBeatEvent(BeatType type)
    {
        if (type == danceBeatType)
        {
            PostBeatAction();
        }
        
    }
    
    
    ///----------------------------------------------------------------------------------------------------------------
    /// Actions on Beat

    private void PreBeatAction()
    {
        isRecieving = true;
        playerLeftMoveDone = DanceMovesTypes.Default;
        playerRightMoveDone = DanceMovesTypes.Default;
        if (OnBeatZombieDance != null)
        {
            // Start AnimatingZombies
            //OnBeatZombieDance(new Moves());
        }
    }
    
    private void BeatAction()
    {
        if (indexDanceMove+1 == coreography.Count)
        {
            indexDanceMove = 0;
        }
        else
        {
            indexDanceMove += 1;
        }
        if (OnBeatZombieDance != null)
        {
            //FinishAnimation Zombies
            OnBeatZombieDance(coreography[indexDanceMove]);
        }
        UpdateColorFloor();
    }
    public void RecievePlayerDance(DanceMovesTypes playerDance, bool isRightArm = false)
    {
        if (isRecieving)
        {
            if (BeatManager.Instance.simplifiedControllers)
            {
                playerRightMoveDone = playerDance;
                playerLeftMoveDone = playerDance;
            }
            else
            {
                if (isRightArm)
                {
                    playerRightMoveDone = playerDance;
                }
                else
                {
                    playerLeftMoveDone = playerDance;
                }
            }

        }
    }
    private void PostBeatAction()
    {
        isRecieving = false;
        
        if (playerInOrda)
        {
            if (BeatManager.Instance.simplifiedControllers)
            {
                if (playerLeftMoveDone == coreography[indexDanceMove].simplyfied && playerRightMoveDone == coreography[indexDanceMove].simplyfied)
                {
                    SendDanceResult(true);
                }
                else
                {
                    SendDanceResult(false);
                }
            }
            else
            {
                if (playerLeftMoveDone == coreography[indexDanceMove].leftArm && playerRightMoveDone == coreography[indexDanceMove].rightArm)
                {
                    SendDanceResult(true);
                }
                else
                {
                    SendDanceResult(false);
                }
            }
        }
        OnBeatZombieDance(new Moves());
    }

    

    public void SendDanceResult(bool succesful)
    {
        if (succesful)
        {
            Debug.Log("BAILASTE BIEN");
        }
        else
        {
            Debug.Log("FALLASTE");
        }
    }


    private void UpdateColorFloor()
    {
        if (colorIndex+1 == pisoColor.Count)
        {
            colorIndex = 0;
        }
        else
        {
            colorIndex += 1;
        }
        piso.color = pisoColor[colorIndex];
    }
    
    public void Move(float timeAnim, Vector3 finalPos, LeanTweenType curve = LeanTweenType.linear)
    {
        walkingTween = LeanTween.moveLocal(this.gameObject, finalPos, timeAnim).setEase(curve).setDestroyOnComplete(true);
    }

    public void OnPauseEventReceiver(bool isPaused)
    {
        if (isPaused)
        {
            walkingTween.pause();
        }
        else
        {
            walkingTween.resume();
        }
        
    }
}
