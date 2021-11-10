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
        enemy.outline.OutlineParameters.DOColor(new Color(0,0,0,0), 0.3f);
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
