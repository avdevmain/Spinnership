using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

public GameObject enemyPrefab;

public bool tutorialMode;
public bool keyTarget;
public bool attacksOnDistance;
private void Start() {
    Spawn();
}


public void Spawn()
{
    Enemy newEnemy = Instantiate(enemyPrefab, transform.position, new Quaternion(0,0,0,0)).GetComponent<Enemy>();
    newEnemy.tutorialMode = tutorialMode;
    newEnemy.keyTarget = keyTarget;
    newEnemy.attacksOnDistance = attacksOnDistance;
}

}
