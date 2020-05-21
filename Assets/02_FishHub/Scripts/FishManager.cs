using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using UnityEngine.AI;

// Create Fish group object
[System.Serializable]
public class AIFish{

    public string GroupeName {get {return m_GroupeName;}}
    public GameObject Prefab {get {return m_Prefab;}}
    public int maxAI {get {return m_maxAI;}}
    public int spawnAmount {get {return m_spawnAmount;}}
    public int scoreValue {get {return m_scoreValue;}}
    public bool randomizeStats {get {return m_randomizeStats;}}
    public bool enableSpawner {get {return m_enableSpawner;}}


    [Header("AI Group Stats")]
    [SerializeField]
    private string m_GroupeName;
    [SerializeField]
    private GameObject m_Prefab;
    [SerializeField]
    [Range(0f, 15f)]
    private int m_maxAI;
    [SerializeField]
    [Range(0f, 5f)]
    private int m_spawnAmount;
    [SerializeField]
    [Range(0f, 5f)]
    private int m_scoreValue;
    [SerializeField]
    private bool m_randomizeStats;
    [SerializeField]
    private bool m_enableSpawner;

    public AIFish(string Name, GameObject Prefab, int MaxAI, int value, bool RandomizeStats, bool EnableSpawner){
        this.m_GroupeName = Name;
        this.m_maxAI = MaxAI;
        this.m_Prefab = Prefab;
        this.m_scoreValue = value;
        this.m_randomizeStats = RandomizeStats;
        this.m_enableSpawner = EnableSpawner;
    }

    public void SetValue(int MaxAI, int SpawnAmount, int scoreValue){
        this.m_maxAI = MaxAI;
        this.m_spawnAmount = SpawnAmount;
        this.m_scoreValue = scoreValue;
    }    
}



public class FishManager : MonoBehaviour {


    public Transform[] Waypoints {get; private set;}

    public float spawnTimer {get {return m_SpawnTimer;}}
    public Vector3 spawnArea{get {return m_SpawnArea;}}
    public int spawnSizeArea{get {return m_SpawnSizeArea;}}

    [Header("Global Settings")]
    [Range(0f, 120f)]
    [SerializeField]
    private float m_SpawnTimer;
    [SerializeField]
    private Vector3 m_SpawnArea = new Vector3(-4f, 7f, -20f);
    [SerializeField]
    [Range(10f, 50f)]
    private int m_SpawnSizeArea;
    
    [Header("AI Groups Settings")]
    public AIFish[] AIFish = new AIFish[3];
    private void Start() {
        RandomizeValues();
        CreateAIGroup();
        InvokeRepeating("SpawnFish", 0.5f, spawnTimer);
    }

    // For each fish group, instantiate new fish with custom parameters from each fish group settings
    // like scoreValue, max fish in scene, spawn Amount
    private void SpawnFish(){
        for (int i = 0; i < AIFish.Count(); i++){
            
            if(AIFish[i].enableSpawner && AIFish[i].Prefab != null){

                GameObject tempGroup = GameObject.Find(AIFish[i].GroupeName);
                if(tempGroup.GetComponentInChildren<Transform>().childCount < AIFish[i].maxAI){
                    for(int y = 0; y < Random.Range(0, AIFish[i].spawnAmount +1); y++){
                        Quaternion randomRotation = Quaternion.Euler(Random.Range(-20, 20), Random.Range(0, 360), 0);
                        GameObject tempsSpawn = Instantiate(AIFish[i].Prefab, RandomPosition(), randomRotation);
                        tempsSpawn.transform.parent = tempGroup.transform;
                        tempsSpawn.AddComponent<FishBehaviour>();
                        tempsSpawn.GetComponent<FishBehaviour>().value = AIFish[i].scoreValue;
                    }                
                }
            }

        }
    }

    // Return a random spawn position in a define area
    public Vector3 RandomPosition(){
        Vector3 randomPos = new Vector3(
            Random.Range(spawnArea.x - spawnSizeArea, spawnArea.x + spawnSizeArea),
            spawnArea.y,
            Random.Range(spawnArea.z - spawnSizeArea, spawnArea.z + spawnSizeArea)
        );
        randomPos = transform.TransformPoint(randomPos * .5f);
        return randomPos;
    }

   
    // If RandomizeValues state is true, give random settings
    private void RandomizeValues(){
        for (int i = 0; i < AIFish.Count(); i++){
            if(AIFish[i].randomizeStats){
                AIFish[i].SetValue(Random.Range(1, 10), Random.Range(1, 5), Random.Range(1, 5));
            }
        }
    }

    // Create children Unity object for each Fish group
    private void CreateAIGroup(){
        for (int i = 0; i < AIFish.Count(); i++){
            GameObject AIFishSpawn;
            AIFishSpawn = new GameObject(AIFish[i].GroupeName);
            AIFishSpawn.transform.parent = this.gameObject.transform;
        }
    }


    // Use predefine waypoints instead of random position
    // Fish behaviour is less natural with manual waypoint

    // public Vector3 RandomWaypoint(){
    //     int randomWP = Random.Range(0, (Waypoints.Count() - 1));
    //     Vector3 randomWaypoint = Waypoints[randomWP].transform.position;
    //     return randomWaypoint;
    // }
    //
    // private void GetWaypoints(){
    //     Waypoints = transform.GetComponentsInChildren<Transform>().Where(c => c.gameObject.tag == "Waypoint").ToArray();
    // }

    
}