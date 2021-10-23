using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{

public IdleState(Entity entity, StateMachine stateMachine) : base(entity, stateMachine)
{
}


Vector3 targetPos;
Vector3 offset;

float distanceToStop = 0.5f;
float timer;
float maxTimer = 4f;



public override void Enter()
{
    entity.animator.SetTrigger("setIdle");

    targetPos = Vector3.zero;
    //entity.idlePos = entity.transform.position;
    Debug.Log("in idleState!");

    timer = Random.Range(1, maxTimer);

    offset = new Vector3(0,5,0);
}

public override void Exit()
{
    entity.animator.ResetTrigger("setIdle");
    Debug.Log("out idleState!");
}

public override void LogicUpdate()
{

    if (DoYouLikeWhatYouSee())
       Debug.Log("Враг близко. Переход в атаку"); //stateMachine.ChangeState(entity.attack);

    timer-= 1*Time.deltaTime; 
    if (timer<=0) //При истечении таймера ожидания переходит в патрулирование
        stateMachine.ChangeState(entity.patrol);
}

public override void PhysicsUpdate()
{
    
}



private bool DoYouLikeWhatYouSee() //Is player close enough
{
    if (Vector3.Distance(entity.transform.position, stateMachine.player.transform.position) < 8)
    {
        return true;
    }
    return false;
}

}