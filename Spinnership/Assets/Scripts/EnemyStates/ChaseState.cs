using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
 public ChaseState(Enemy enemy, StateMachine stateMachine) : base(enemy, stateMachine)
{
}
float attackDistance = 1.5f;
public override void Enter()
{
    enemy.anim.SetTrigger("setFlying");
}

public override void Exit()
{  
    enemy.anim.ResetTrigger("setFlying");
}

public override void LogicUpdate()
{
    MoveToTarget();

    CheckDist();
}

public override void PhysicsUpdate()
{

}

private void MoveToTarget()
{
    //Vector3 targetPos = stateMachine.player.transform.position;
    Vector3 targetPos = enemy.target.transform.position;

    enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, Quaternion.LookRotation(targetPos - enemy.transform.position), Time.deltaTime * 10f);
    enemy.transform.rotation = Quaternion.Euler(0, enemy.transform.rotation.eulerAngles.y, 0);

    enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, targetPos, enemy.speed * Time.deltaTime);


    
}

private void CheckDist()
{
    float distance = Vector3.Distance(enemy.transform.position, enemy.target.transform.position);
    if (distance <= attackDistance)
    {   
        //Perform attack
        stateMachine.ChangeState(enemy.attack);
    }
}

}
