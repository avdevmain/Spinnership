using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fly : Entity
{

    public StateMachine stateMachine;
    public IdleState idle;
    private void Start()
    {
        stateMachine = new StateMachine();

        idle = new IdleState(this, stateMachine);

        stateMachine.Initialize(idle);
    }


    private void Update() {
        stateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate() {
        stateMachine.CurrentState.PhysicsUpdate();
    }
}

