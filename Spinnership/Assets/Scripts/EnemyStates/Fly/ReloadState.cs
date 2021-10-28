using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadState : State
{
    public ReloadState(Enemy enemy, StateMachine stateMachine) : base(enemy, stateMachine)
    {
    }

    public override void Enter()
    {
        enemy.anim.SetTrigger("setReload");
        Debug.Log("in reloadState!");
    }

    public override void Exit()
    {
        enemy.anim.ResetTrigger("setReload");
        Debug.Log("out reloadState!");
    }

    public override void LogicUpdate()
    {}

    public override void PhysicsUpdate()
    {}

    public override void GetStopEvent()
    {
        stateMachine.ChangeState(enemy.chase);
    }
}
