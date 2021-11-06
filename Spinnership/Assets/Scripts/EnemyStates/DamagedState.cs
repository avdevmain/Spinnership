using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DamagedState : State
{
    public DamagedState(Enemy enemy, StateMachine stateMachine) : base(enemy, stateMachine)
    {
    }


    public override void Enter()
    {
        Debug.Log("in damagedState!");
        enemy.anim.SetTrigger("setDamaged");
        enemy.target = stateMachine.player;
        enemy.outline.OutlineParameters.DOColor(Color.red, 0.2f);
    }

    public override void Exit()
    {
        enemy.anim.ResetTrigger("setDamaged");
        Debug.Log("out damagedState!");
        enemy.rb.isKinematic = true;
        enemy.outline.OutlineParameters.DOColor(new Color32(144, 44,0,255), 0.2f);

    }

    public override void LogicUpdate()
    {
    }

    public override void PhysicsUpdate()
    {}

    public override void GetStopEvent(string letter)
    {
        if (letter == "dmg")
            stateMachine.ChangeState(enemy.chase);  
    }
}
