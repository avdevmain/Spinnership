using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{

public IdleState(Enemy enemy, StateMachine stateMachine) : base(enemy, stateMachine)
{
}


Vector3 targetPos;
Vector3 offset;

float distanceToStop = 0.5f;
float timer;
float maxTimer = 4f;



public override void Enter()
{

    targetPos = Vector3.zero;
    //enemy.idlePos = enemy.transform.position;
    Debug.Log("in idleState!");

    timer = Random.Range(1, maxTimer);

    offset = new Vector3(0,5,0);
}

public override void Exit()
{
    Debug.Log("out idleState!");
}

public override void LogicUpdate()
{

    //if (DoYouLikeWhatYouSee())
  //     Debug.Log("Враг близко. Переход в атаку"); //stateMachine.ChangeState(entity.attack);

    timer-= 1*Time.deltaTime; 
    if (timer<=0) //При истечении таймера ожидания переходит в патрулирование
        stateMachine.ChangeState(enemy.patrol);
}

public override void PhysicsUpdate()
{
    
}





}