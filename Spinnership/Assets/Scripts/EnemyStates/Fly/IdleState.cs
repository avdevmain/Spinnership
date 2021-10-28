using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{

public IdleState(Enemy enemy, StateMachine stateMachine) : base(enemy, stateMachine)
{
}

Vector3 offset;

float distanceToStop = 0.5f;
float timer;
float maxTimer = 4f;



public override void Enter()
{
    enemy.anim.SetTrigger("setIdle");

    Debug.Log("in idleState!");

    timer = Random.Range(1, maxTimer);

    offset = new Vector3(0,5,0);
}

public override void Exit()
{
    enemy.anim.ResetTrigger("setIdle");
    Debug.Log("out idleState!");
}

public override void LogicUpdate()
{

    timer-= 1*Time.deltaTime; 
    if (timer<=0) //При истечении таймера ожидания переходит в патрулирование
        stateMachine.ChangeState(enemy.patrol);
}

public override void PhysicsUpdate()
{
    
}





}