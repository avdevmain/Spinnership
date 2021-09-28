using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{

public IdleState(Entity entity, StateMachine stateMachine) : base(entity, stateMachine)
{
}

Vector3 idlePos;
float upForce = 75f;
Rigidbody rb;
public override void Enter()
{
    idlePos = entity.transform.position;
    rb = entity.GetComponent<Rigidbody>();
    Debug.Log("Привет, я жду =)");
}

public override void Exit()
{
    Debug.Log("Exit");
}

public override void LogicUpdate()
{
    Debug.Log("Amogus");
}

public override void PhysicsUpdate()
{
        if (entity.transform.position.y < idlePos.y)
        {
            rb.AddForce(Vector3.up * upForce);
            
        }
}
}