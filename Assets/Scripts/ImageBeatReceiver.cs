using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageBeatReceiver : MonoBehaviour
{

    public Color colorA;
    public Color colorB;
    public Image thisImage;

    public BeatType myBeatType;

    private void OnEnable()
    {
        BeatManager.OnBeat += OnBeatAction;
    }

    private void OnDisable()
    {
        BeatManager.OnBeat -= OnBeatAction;
    }

    private void OnBeatAction(BeatType type)
    {
        if (type == myBeatType)
        {
            BeatAction();
        }
    }

    public void BeatAction()
    {
        if (thisImage.color == colorA)
        {
            thisImage.color = colorB;
        }
        else
        {
            thisImage.color = colorA;
        }
    }
}
