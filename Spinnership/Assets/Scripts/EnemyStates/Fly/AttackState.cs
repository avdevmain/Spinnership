using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
 public AttackState(Entity entity, StateMachine stateMachine) : base(entity, stateMachine)
{
}

public override void Enter()
{
    Debug.Log("in AttackState");
}

public override void Exit()
{
    Debug.Log("out AttackState");
}

public override void LogicUpdate()
{

}

public override void PhysicsUpdate()
{

}


}
