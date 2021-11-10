using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

//Start with Clear waves / Defend  objectives
//Start with day / night

public UI_Manager ui_manager;
public Material daySky;
public Material nightSky;

public Light sun;


public GameObject[] levelPrefabs;

public LvlEnemyManager enemyManager;

private void Start() {

    
    levelPrefabs = Resources.LoadAll<GameObject>("Prefabs/Levels/");


    Instantiate(levelPrefabs[Random.Range(0,levelPrefabs.Length)]);
    enemyManager = FindObjectOfType<LvlEnemyManager>();

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

    GameObject keyObj = FindObjectOfType<EnemyObjective>().gameObject;
    if (keyObj!=null)
    {
        rnd = Random.Range(0,3);
        if (rnd == 0) enemyManager.keyTarget = true;
    }

}

}
