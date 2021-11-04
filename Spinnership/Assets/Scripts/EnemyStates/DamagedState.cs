using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public override void Exit()
    {
        enemy.anim.ResetTrigger("setDamaged");
        Debug.Log("out damagedState!");
        enemy.rb.isKinematic = true;

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
