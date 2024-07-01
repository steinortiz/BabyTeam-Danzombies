using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public enum AnimationType
{
    NONE,
    SEMI,
    COMPLETE
}

public class UiController : MonoBehaviour
{
    [SerializeField] public Canvas gameCanvas;
    [SerializeField] public Canvas pauseCanvas;
    [SerializeField] private GameObject buttonsContainer;
    
    [Header("Animacion Central")]
    [SerializeField] private RectTransform centralObj;
    [SerializeField] private Vector3 initialPosCentralObj;
    [SerializeField] private Vector3 finalPosCentralObj;
    [SerializeField] private float animCentralTime;
    [SerializeField] private LeanTweenType animCentralType;

    [Header("Animacion Bordes")]
    
    [SerializeField] private RectTransform leftObj;
    [SerializeField] private Vector3 initialPosLeftObj;
    [SerializeField] private Vector3 finalPosLeftObj;
    
    [SerializeField] private RectTransform rightObj;
    [SerializeField] private Vector3 initialPosRightObj;
    [SerializeField] private Vector3 finalPosRightObj;

    [SerializeField] private float animBordesTime;
    [SerializeField] private LeanTweenType animBordesType;
    private LTDescr leftTween;
    private LTDescr rightTween;
    
    [Header("Animacion Cortinas")]
    
    [SerializeField] private RectTransform cortinaSemi;
    [SerializeField] private Vector3 semiOpenPosition;
    [SerializeField] private RectTransform cortinaFull;
    [SerializeField] private Vector3 fullOpenPosition;

    [SerializeField] private float animCortinasTime;
    [SerializeField] private LeanTweenType animCortinasType;
    
    public static UiController Instance { get; private set; }

    private void Awake() 
    {

        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this;
        } 
    }

    private void OnEnable()
    {
        
        GameController.OnPauseEvent += OnPauseEventReceiver;
        GameController.OnPlayEvent += SetStateGameUI;
    }

    private void OnDisable()
    {
        
        GameController.OnPauseEvent -= OnPauseEventReceiver;
        GameController.OnPlayEvent -= SetStateGameUI;
    }

    private void Start()
    {
        UnPauseUI();
    }

    public void SetStateGameUI(bool active)
    {
        gameCanvas.enabled = active;
    }
    private void OnPauseEventReceiver(bool isPaused)
    {
        if (isPaused)
        {
            PauseUI();
        }
        else
        {
            UnPauseUI();
        }
    }
    private void PauseUI()
    {
        //LeanTween.pauseAll();
        buttonsContainer.SetActive(false);
        pauseCanvas.enabled = true;
        AnimateBordes();
        AnimateCentral();
    }
    private void UnPauseUI()
    {
        leftTween?.pause();
        rightTween?.pause();
        leftObj.localPosition = initialPosLeftObj;
        rightObj.localPosition = initialPosRightObj;
        centralObj.localPosition = initialPosCentralObj;
        pauseCanvas.enabled = false;
        buttonsContainer.SetActive(false);
    }
    private void AnimateBordes()
    {
        leftTween = LeanTween.moveLocal(leftObj.gameObject, finalPosLeftObj, animBordesTime).setEase(animBordesType);
        rightTween = LeanTween.moveLocal(rightObj.gameObject, finalPosRightObj, animBordesTime).setEase(animBordesType);
    }

    private void AnimateCentral()
    {
        LeanTween.moveLocal(centralObj.gameObject, finalPosCentralObj, animCentralTime).setEase(animCentralType).setOnComplete(
            () =>
            {
                buttonsContainer.SetActive(true);
            });
    }
    
    
   public void CloseFullCortina(UnityAction callback =null)
   {
       MoveFullCortina(Vector3.zero,callback);
   }

   public void CloseSemiCortina(Vector3 initialposition, UnityAction callback = null)
   {
       cortinaSemi.localPosition= initialposition;
       semiOpenPosition = -initialposition;
       MoveSemiCortina(Vector3.zero,callback);
   }

   private void MoveSemiCortina(Vector3 position,UnityAction callback =null)
   {
       LeanTween.moveLocal(cortinaSemi.gameObject, position, animCortinasTime).setEase(animCortinasType).setOnComplete(
           () =>
           {
               callback?.Invoke();
           });
   }
   private void MoveFullCortina(Vector3 position,UnityAction callback =null)
   {
       LeanTween.moveLocal(cortinaFull.gameObject, position, animCortinasTime).setEase(animCortinasType).setOnComplete(
           () =>
           {
               callback?.Invoke();
           });
   }
   

    public void OpenCortinas()
    {
        MoveFullCortina(fullOpenPosition);
        MoveSemiCortina(semiOpenPosition);
    }


    public void UnPauseButtonAction()
    {
        GameController.Instance.SetPauseGame(false);
    }

}
