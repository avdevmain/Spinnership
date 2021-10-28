using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : Enemy
{
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        anim = GetComponent<Animator>();

        stateMachine = new StateMachine();

        idle = new IdleState(this, stateMachine);

        patrol = new PatrolState(this, stateMachine);

        chase = new ChaseState(this, stateMachine);

        attack = new AttackState(this, stateMachine);

        damaged = new DamagedState(this, stateMachine);

        reload = new ReloadState(this, stateMachine);

        stateMachine.Initialize(idle);
    }


    private void Update() {
        stateMachine.CurrentState.LogicUpdate();

        if ((DoYouLikeWhatYouSee())&&((stateMachine.CurrentState == idle)||(stateMachine.CurrentState == patrol)))
        {
            stateMachine.ChangeState(chase);
        }
    }
    private bool DoYouLikeWhatYouSee() //Is player close enough
    {
        if (Vector3.Distance(transform.position, stateMachine.player.transform.position) < 8)
        {
            return true;
        }
        return false;
    }
    private void FixedUpdate() {
        stateMachine.CurrentState.PhysicsUpdate();
    }

}