using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class OrdasSpawnerController : MonoBehaviour
{
    [SerializeField] private List<OrdaBeatReceiver> ordaPrefabs =new List<OrdaBeatReceiver>();
    [SerializeField] private ZombieBrain zombiePrefab;
    [SerializeField] private List<DancerSO> costumes = new List<DancerSO>();
    [SerializeField] private List<CoreographySO> coreos = new List<CoreographySO>();

    [Header("Animation Settings")] 
    public Vector3 finalPosition;
    public int bpmDurationMove;
    public LeanTweenType animationCurve;
    
    public static OrdasSpawnerController Instance { get; private set; }
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this.gameObject); 
        } 
        else 
        { 
            Instance = this;
            //DontDestroyOnLoad(this);
        } 
    }
    public void SpawnOrda()
    {
        
        OrdaBeatReceiver ordaInstance = Instantiate(ordaPrefabs[Random.Range(0, ordaPrefabs.Count)], transform.position, transform.rotation);
        int zombiesNum = Random.Range(1, ordaInstance.zombiesPos.Count+1);
        ordaInstance.zombiesPos = ordaInstance.zombiesPos.OrderBy(i => Guid.NewGuid()).ToList();
        for (int i = 0; i<=zombiesNum-1; i++)
        {
            ZombieBrain zombie = Instantiate(zombiePrefab, ordaInstance.zombiesPos[i]);
            zombie._bodyAssets = costumes[Random.Range(0, costumes.Count)];
            zombie.fatherZone = ordaInstance;
            zombie.Prepare();
        }
        ordaInstance.coreography = coreos[Random.Range(0, coreos.Count)].coreography;
        ordaInstance.Move(BeatManager.Instance.bpmDuration*bpmDurationMove,finalPosition,animationCurve);
    }
}
