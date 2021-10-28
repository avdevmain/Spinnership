using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
public PatrolState(Enemy enemy, StateMachine stateMachine) : base(enemy, stateMachine)
{
}

Vector3 targetPos;

float acceptableDist = 0.25f;
private float _animationTimePosition;

public override void Enter()
{
    enemy.anim.SetTrigger("setFlying");
    Debug.Log("in patrolState!");
    GetPatrolPoint();
}

public override void Exit()
{
    enemy.anim.ResetTrigger("setFlying");
    Debug.Log("out patrolState!");
}

public override void LogicUpdate()
{
    MoveToPoint();

    CheckDist();
}

public override void PhysicsUpdate()
{}


private void GetPatrolPoint()
{
    
    targetPos = enemy.gameObject.GetComponent<EnemyPatrolRoute>().getNextPoint();

    if (targetPos == Vector3.zero)
    {
        Debug.Log("Error: setting target position for patrol");
        return;
    }
   // enemy.idlePos = targetPos;
  
}

private void MoveToPoint()
{
    if (targetPos == Vector3.zero) return;

    _animationTimePosition += Time.deltaTime;
   enemy.transform.position = Vector3.Lerp(enemy.transform.position, targetPos, enemy.speed * enemy.MoveCurve.Evaluate(_animationTimePosition) * Time.deltaTime);

    enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, Quaternion.LookRotation(targetPos - enemy.transform.position), Time.deltaTime * 10f);
    enemy.transform.rotation = Quaternion.Euler(0, enemy.transform.rotation.eulerAngles.y, 0);
}

private void CheckDist()
{
    if (Vector3.Distance(enemy.transform.position, targetPos) <= acceptableDist)
    {   _animationTimePosition = 0;
        targetPos = Vector3.zero;
        stateMachine.ChangeState(enemy.idle);

    }
}

}
