using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
public PatrolState(Entity entity, StateMachine stateMachine) : base(entity, stateMachine)
{
}

Vector3 targetPos;

float acceptableDist = 0.25f;
private float _animationTimePosition;

public override void Enter()
{
    entity.animator.SetTrigger("setFly");
    Debug.Log("in patrolState!");
    GetPatrolPoint();
}

public override void Exit()
{
    entity.animator.ResetTrigger("setFly");
    Debug.Log("out patrolState!");
}

public override void LogicUpdate()
{
    Move();

    CheckDist();
}

public override void PhysicsUpdate()
{}


private void GetPatrolPoint()
{
    
    targetPos = entity.gameObject.GetComponent<EnemyPatrolRoute>().getNextPoint();

    if (targetPos == Vector3.zero)
    {
        Debug.Log("Error: setting target position for patrol");
        return;
    }
   // entity.idlePos = targetPos;
  
}

private void Move()
{
    if (targetPos == Vector3.zero) return;

    _animationTimePosition += Time.deltaTime;
   entity.transform.position = Vector3.Lerp(entity.transform.position, targetPos, entity.speed * entity.MoveCurve.Evaluate(_animationTimePosition));

}

private void CheckDist()
{
    if (Vector3.Distance(entity.transform.position, targetPos) <= acceptableDist)
    {   _animationTimePosition = 0;
        targetPos = Vector3.zero;
        stateMachine.ChangeState(entity.idle);

    }
}

}
