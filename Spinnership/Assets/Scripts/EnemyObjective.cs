using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjective : Entity
{
    LevelManager levelManager;
    private void Start() {
        levelManager = FindObjectOfType<LevelManager>();
    }
    public override void GetDamage(int dmgValue,float dmgMod, Vector3 point)
    {
        base.GetDamage(dmgValue, dmgMod, point);
        levelManager.MinusPercentage(dmgValue);

    }
}
