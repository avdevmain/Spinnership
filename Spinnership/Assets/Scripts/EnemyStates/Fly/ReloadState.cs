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
        Debug.Log("in reloadState!");
    }

    public override void Exit()
    {
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
