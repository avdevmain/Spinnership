using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
public AttackState(Enemy enemy, StateMachine stateMachine) : base(enemy, stateMachine)
{
}

public override void Enter()
{
    Debug.Log("in attackState!");

    
}

public override void Exit()
{
    Debug.Log("out attackState!");
}

public override void LogicUpdate()
{}

public override void PhysicsUpdate()
{}

public override void GetStopEvent()
{
    stateMachine.player.GetDamage(enemy.attackPower,1, enemy.transform.position);
    stateMachine.ChangeState(enemy.reload);
}

}
