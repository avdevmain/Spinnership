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
    if (!enemy.attacksOnDistance)
    {//Melee attack
        if (Random.Range(0,2) <1)
            enemy.anim.SetTrigger("setMAttack");
        else
            enemy.anim.SetTrigger("setMAttack2");    
    }
    else
    {//Shoot with something
        enemy.anim.SetTrigger("setDAttack");
    }
    Debug.Log("in attackState!");
}

public override void Exit()
{
    enemy.anim.ResetTrigger("setMAttack");
    enemy.anim.ResetTrigger("setMAttack2");
    enemy.anim.ResetTrigger("setDAttack");
    Debug.Log("out attackState!");
}

public override void LogicUpdate()
{}

public override void PhysicsUpdate()
{}

public override void GetStopEvent(string letter)
{
    enemy.target.GetDamage(enemy.attackPower,1, enemy.transform.position);
    stateMachine.ChangeState(enemy.reload);
}

}
