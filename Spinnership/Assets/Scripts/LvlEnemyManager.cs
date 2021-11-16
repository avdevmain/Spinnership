using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LvlEnemyManager : MonoBehaviour
{

public UI_Manager ui_Manager;

public LevelManager levelManager;

public float timeBetweenSpawns = 1f;
public const float timeBetweenWaves = 3.5f;
private Coroutine waveTimer;
private Coroutine spawnTimer;

public BoxCollider[] spawnZones;

public SpawnWaves[] waves;


public bool tutorialMode;
public bool keyTarget;

public int maxEnemiesOnScreen = 2;
public int currEnemiesOnScreen = 0;
private int currWave = 0;
private bool finished = false;

public Light sun;
public Material daySky;
public Material nightSky;
private void Start() {
    spawnZones = GetComponentsInChildren<BoxCollider>();
    ui_Manager = FindObjectOfType<UI_Manager>();
    levelManager = FindObjectOfType<LevelManager>();
    ui_Manager.UpdateWaveText(currWave+1, waves.Length); 

    waveTimer = StartCoroutine(WaveTimer(timeBetweenWaves * 2));

        /*
        int rnd = Random.Range(0,3);

        if (rnd == 0) 
        {
            RenderSettings.skybox = nightSky;
            sun.intensity = 0.2f;
        } else 
        {
            RenderSettings.skybox = daySky;
            sun.intensity = 1;
        }

        */
}





private void Update() {

    if (finished) return;
    
    if ((currEnemiesOnScreen<maxEnemiesOnScreen) && (spawnTimer == null) && (waveTimer == null))
    {
        spawnTimer = StartCoroutine(SpawnTimer());
        Spawn();
    }

    if (currEnemiesOnScreen == 0)
    {
        if (IsWaveSpawnedOut() && (currWave+1 >= waves.Length))
        {
            ProcessFinish();
        }
    }


    if(Input.GetKeyDown(KeyCode.Space))
    {
        Spawn();
    }
}

public void Spawn()
{
    Vector3 position = GetPositionToSpawn();

    if (IsWaveSpawnedOut())
    {       
        if (currEnemiesOnScreen != 0) return;
        if (currWave+1 >= waves.Length) return;

        waveTimer = StartCoroutine(WaveTimer());
        currWave += 1;
        ui_Manager.UpdateWaveText(currWave+1, waves.Length); 
        
    }

    int whichEnemy = Random.Range(0,waves[currWave].enemyToSpawn.Length);
    while (waves[currWave].enemyToSpawn[whichEnemy].amount ==0)
     whichEnemy = Random.Range(0,waves[currWave].enemyToSpawn.Length);


    GameObject prefab = waves[currWave].enemyToSpawn[whichEnemy].enemyPrefab;

    Enemy newEnemy = Instantiate(prefab, position, new Quaternion(0,0,0,0)).GetComponent<Enemy>();
    newEnemy.tutorialMode = tutorialMode;
    newEnemy.keyTarget = keyTarget;


    newEnemy.enemyManager = this;
    currEnemiesOnScreen +=1;
    waves[currWave].enemyToSpawn[whichEnemy].amount -= 1;

}

    public void ProcessFinish()
    {
        finished = true;
        levelManager.ProcessFinish();
    }

    private bool IsWaveSpawnedOut()
    {
        for (int i =0; i<waves[currWave].enemyToSpawn.Length; i++)
        {
            if (waves[currWave].enemyToSpawn[i].amount != 0)
                return false;
        }

        return true;
    }

    private Vector3 GetPositionToSpawn()
    {
        return spawnZones[Random.Range(0, spawnZones.Length)].transform.position;;
    }

    private IEnumerator SpawnTimer()
    {
        yield return new WaitForSecondsRealtime(timeBetweenSpawns);
        spawnTimer = null;
    }

    private IEnumerator WaveTimer(float time = timeBetweenWaves)
    {
        yield return new WaitForSecondsRealtime(timeBetweenWaves);
        waveTimer = null;
    }



}


[System.Serializable]
public class SpawnWaves
{
    public ToSpawn[] enemyToSpawn;
}

[System.Serializable]
public class ToSpawn
{
    public GameObject enemyPrefab;
    public int amount; 
}


