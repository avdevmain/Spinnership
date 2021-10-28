using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedState : State
{
    public DamagedState(Enemy enemy, StateMachine stateMachine) : base(enemy, stateMachine)
    {
    }

    int hpleft;

    public override void Enter()
    {
        Debug.Log("in damagedState!");

        hpleft = enemy.GetHealth();
        
    
        if (hpleft <=0) //Dead
        {
            Debug.Log("Die");

        }
        else
        {
            
        }

    }

    public override void Exit()
    {
        Debug.Log("out damagedState!");
        enemy.rb.isKinematic = true;

    }

    public override void LogicUpdate()
    {
    }

    public override void PhysicsUpdate()
    {}

    public override void GetStopEvent()
    {
        if (hpleft>0)
            stateMachine.ChangeState(enemy.chase);
        else
            enemy.TimeToDie();
    }
}
