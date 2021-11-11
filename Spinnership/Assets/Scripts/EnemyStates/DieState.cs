using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DieState : State
{
    public DieState(Enemy enemy, StateMachine stateMachine) : base(enemy, stateMachine)
    {
    }
   
   
   public override void Enter()
    {
        //enemy.outline.OutlineParameters.DOColor(new Color(0,0,0,0), 0.3f);
        enemy.outline.FrontParameters.DOColor(new Color(0,0,0,0), 0.3f);
        enemy.outline.FrontParameters.FillPass.DOColor("_PublicColor",new Color32(255,0,0,100), 0.2f);
        enemy.outline.BackParameters.Enabled = false;
        enemy.enemyManager.currEnemiesOnScreen-=1;
        enemy.anim.SetTrigger("setDie");
    }

    public override void Exit()
    {}

    public override void LogicUpdate()
    {
    }

    public override void PhysicsUpdate()
    {}

    public override void GetStopEvent(string letter)
    {
        if (letter == "die")
            enemy.TimeToDie();
    }

}
