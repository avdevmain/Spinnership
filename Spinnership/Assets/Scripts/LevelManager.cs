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

public int currentResult = 100;



private void Start() {

    currentResult = 100;

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

    if (FindObjectOfType<EnemyObjective>())
    {
        rnd = Random.Range(0,3);
        if (rnd == 0) 
        {
            enemyManager.keyTarget = true;
            ui_manager.SetObjectiveTitle("Protect food");
        }
        else
        {
            ui_manager.SetObjectiveTitle("Clear the area");
        }
    }
    else
    {
        ui_manager.SetObjectiveTitle("Clear the area");
    }
    enemyManager.enabled = true;
}

    public void MinusPercentage(int value)
    {
        
        currentResult -= value;
        if (currentResult<=0) currentResult = 0;
        ui_manager.UpdatePercentageText(currentResult, value);
    }

    public void ProcessFinish()
    {
        ui_manager.ProcessFinish(currentResult);
    }

}
