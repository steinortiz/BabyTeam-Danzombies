using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameController : MonoBehaviour
{
    [SerializeField] private BeatType brainBeatType;
    [SerializeField] private GameObject brainUIObj;
    [Range(1,2), SerializeField] private float animBrainScale;
    [SerializeField] private LeanTweenType animBrainType;
    private LTDescr animBrainTween;
    
    private void OnEnable()
    {
        BeatManager.OnBeat += OnBeatEvent;
        GameController.OnPauseEvent += OnPauseEventReceiver;
    }

    private void OnDisable()
    {
        BeatManager.OnBeat -= OnBeatEvent;
        GameController.OnPauseEvent -= OnPauseEventReceiver;
    }

    private void OnBeatEvent(BeatType beatType)
    {
        if (beatType == brainBeatType)
        {
            AnimateBrain();
        }
        
    }

    private void AnimateBrain()
    {
        float animTime = (float)(BeatManager.Instance.bpmDuration/2 * 0.7f);
        brainUIObj.transform.localScale = Vector3.one;
        animBrainTween = LeanTween.scale(brainUIObj,Vector3.one*animBrainScale,animTime).setLoopPingPong(1);

    }

    private void OnPauseEventReceiver(bool ispaused)
    {
        if (ispaused)
        {
            animBrainTween?.pause();
        }
        else
        {
            animBrainTween?.resume();
        }
    }
}
