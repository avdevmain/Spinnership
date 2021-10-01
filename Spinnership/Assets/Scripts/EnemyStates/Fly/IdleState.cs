using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{

public IdleState(Entity entity, StateMachine stateMachine) : base(entity, stateMachine)
{
}


private bool cooldownPatrol;

Vector3 targetPos;

float distanceToStop = 0.5f;
float timer;
float maxTimer = 3f;

public override void Enter()
{
    targetPos = Vector3.zero;
    entity.idlePos = entity.transform.position;
    Debug.Log("in idleState!");
}

public override void Exit()
{
    Debug.Log("out idleState!");
}

public override void LogicUpdate()
{
    GetPatrolPoint();

    if (DoYouLikeWhatYouSee())
        stateMachine.ChangeState(entity.attack);
}

public override void PhysicsUpdate()
{
    Float();
    Move();
}


private void Float()
{
    //if (targetPos!=Vector3.zero) return;

    if (entity.transform.position.y < entity.idlePos.y)
    {
        entity.rb.AddForce(Vector3.up * entity.upForce, ForceMode.Force);
        
    }
}

private void GetPatrolPoint()
{
    if (targetPos != Vector3.zero) return;

    targetPos = entity.transform.position + Random.insideUnitSphere * 3;
    targetPos.z = entity.transform.position.z;

    entity.idlePos = targetPos;

    
}



private void Move()
{
    if (targetPos == Vector3.zero) return;

    var direction = Vector3.zero;
    if(Vector3.Distance(entity.transform.position, targetPos) > distanceToStop)
    {
        direction = targetPos - entity.transform.position;
        entity.rb.AddRelativeForce(direction.normalized * entity.speed, ForceMode.Force);
    }
    else
    {
        targetPos = Vector3.zero;
    }

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