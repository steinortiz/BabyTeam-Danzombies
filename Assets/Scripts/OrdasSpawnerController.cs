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
    [SerializeField] private List<DancerSO> bodytypes = new List<DancerSO>();

    [Header("Animation Settings")] 
    public Vector3 finalPosition;
    public float velocity;
    public LeanTweenType animationCurve;
    
    


    private void Start()
    {
        PlayGame();
        SpawnOrda();
        
    }

    private void PlayGame()
    {
        BeatManager.Instance.PlayBeat();
    }

    private void SpawnOrda()
    {
        
        OrdaBeatReceiver ordaInstance = Instantiate(ordaPrefabs[Random.Range(0, ordaPrefabs.Count)], transform.position, transform.rotation);
        int zombiesNum = Random.Range(1, ordaInstance.zombiesPos.Count+1);
        ordaInstance.zombiesPos = ordaInstance.zombiesPos.OrderBy(i => Guid.NewGuid()).ToList();
        for (int i = 0; i<=zombiesNum-1; i++)
        {
            ZombieBrain zombie = Instantiate(zombiePrefab, ordaInstance.zombiesPos[i]);
            zombie._bodyAssets = bodytypes[Random.Range(0, bodytypes.Count)];
            zombie.fatherZone = ordaInstance;
            zombie.Prepare();
        }
        ordaInstance.Move(velocity,finalPosition,animationCurve);
    }
}
