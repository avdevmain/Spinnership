using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
 public ChaseState(Enemy enemy, StateMachine stateMachine) : base(enemy, stateMachine)
{
}
float acceptableDist = 1f;
public override void Enter()
{
    Debug.Log("in ChaseState");
}

public override void Exit()
{  
    Debug.Log("out ChaseState");
}

public override void LogicUpdate()
{
    MoveToPlayer();

    CheckDist();
}

public override void PhysicsUpdate()
{

}

private void MoveToPlayer()
{
    Vector3 targetPos = stateMachine.player.transform.position;

    enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, Quaternion.LookRotation(targetPos - enemy.transform.position), Time.deltaTime * 10f);
    enemy.transform.rotation = Quaternion.Euler(0, enemy.transform.rotation.eulerAngles.y, 0);

    enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, targetPos, 1f * acceptableDist * enemy.speed * Time.deltaTime);


    
}

private void CheckDist()
{
    float distance = Vector3.Distance(enemy.transform.position, stateMachine.player.transform.position);
    if (distance <= acceptableDist)
    {   
        //Perform attack
        stateMachine.ChangeState(enemy.attack);
    }
}

}
