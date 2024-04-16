using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrdaBeatReceiver : MonoBehaviour
{

    public Color colorA;
    public Color colorB;
    public Image thisImage;

    public BeatType myBeatType;
    
    public bool isRecieving;

    // Zmbies DanceList

    public List<DanceMovesTypes> coreography = new List<DanceMovesTypes>();
    public int indexDanceMove=-1;
    
    //playerValues

    public bool playerInOrda;
    private DanceMovesTypes playerMoveDone;
    //public bool isDanceCorrect;


    private void OnEnable()
    {
        BeatManager.OnBeat += OnBeatAction;
        BeatManager.OnPreBeat += OnPreBeatAction;
        BeatManager.OnPostBeat += OnPostBeatAction;
    }

    private void OnDisable()
    {
        BeatManager.OnBeat -= OnBeatAction;
        BeatManager.OnPreBeat -= OnPreBeatAction;
        BeatManager.OnPostBeat -= OnPostBeatAction;
    }

    private void OnBeatAction(BeatType type)
    {
        if (type == myBeatType)
        {
            BeatAction();
        }
    }

    private void OnPreBeatAction(BeatType type)
    {
        if (type == myBeatType)
        {
            PreBeatAction();
        }
    }

    private void OnPostBeatAction(BeatType type)
    {
        if (type == myBeatType)
        {
            PostBeatAction();
        }
    }

    private void PreBeatAction()
    {
        isRecieving = true;
        playerMoveDone = DanceMovesTypes.Default;
        // Mandar señal de preparacion.
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
        
        //mandar señal de beat de baile
        ///esto deberia estar en un script del controlador de la wea del piso.
        if (thisImage.color == colorA)
        {
            thisImage.color = colorB;
        }
        else
        {
            thisImage.color = colorA;
        }
    }
    private void PostBeatAction()
    {
        //mandar señal de bajar los brazos
        //preguntar si el baile del player fue correcto
        // dañar en caso de que no
        if (playerInOrda)
        {
            if (playerMoveDone == coreography[indexDanceMove])
            {
                Debug.Log("CONGRATULATIONS");
    
            }
            else
            {
                Debug.Log("hiciste mal la wea");
            }
        }
    }

    public void RecievePlayerDance(DanceMovesTypes playerDance)
    {
        if (BeatManager.Instance.onMargen && isRecieving)
        {
            isRecieving = false;
            playerMoveDone = playerDance; 
        }
    }
}
