using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fly : Entity
{
     
    public StateMachine stateMachine;

    private void Start()
    {

        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();

        stateMachine = new StateMachine();

        idle = new IdleState(this, stateMachine);

        patrol = new PatrolState(this, stateMachine);

        attack = new AttackState(this, stateMachine);

        stateMachine.Initialize(idle);
    }


    private void Update() {
        stateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate() {
        stateMachine.CurrentState.PhysicsUpdate();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(idlePos, 0.5f);
    }
}

