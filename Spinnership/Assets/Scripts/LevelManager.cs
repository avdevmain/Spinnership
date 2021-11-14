using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{

//Start with Clear waves / Defend  objectives
//Start with day / night
public GameObject playerPrefab;
public UI_Manager ui_manager;





public List<string> sceneNames;

public LvlEnemyManager enemyManager;

public int currentResult = 100;

private string loadedLevel;



    private void Start() {
  
    sceneNames = new List<string>();
    sceneNames.Add("1_Meadow");
    sceneNames.Add("2_DeepForest");
    sceneNames.Add("3_Camp");
    sceneNames.Add("4_ForestryZone");
    sceneNames.Add("5_RockValley");
    sceneNames.Add("6_MushroomField");


     SetupLevel();

    }

    private void SetupLevel()
    {

        currentResult = 100;
        ui_manager.result_text.text = currentResult + "%";

        
        if (loadedLevel!=null)
            {
                //Destroy(level); //Пока уровни были префабами
                //SceneManager.UnloadSceneAsync(loadedLevel); //Пока уровни были дополнительными сценами
                Enemy[] enemiesLeft =  FindObjectsOfType<Enemy>();
                for (int i =0; i<enemiesLeft.Length; i++)
                    Destroy(enemiesLeft[i].gameObject);
            }

        //level = Instantiate(levelPrefabs[Random.Range(0,levelPrefabs.Length)]);
        
        loadedLevel = sceneNames[Random.Range(0, sceneNames.Count)];
        
        SceneManager.LoadScene(loadedLevel, LoadSceneMode.Single);
        

        if (FindObjectOfType<EnemyObjective>())
        {
            int rnd = Random.Range(0,3);
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

    public void Restart()
    {
        SetupLevel();
    }
}
