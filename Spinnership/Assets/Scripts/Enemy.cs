using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public Animator anim;
    public int attackPower;
    public StateMachine stateMachine;

    public AnimationCurve MoveCurve;  
    public IdleState idle;
    public PatrolState patrol;
    public ChaseState chase;
    public AttackState attack;
    public ReloadState reload;
    public DamagedState damaged;
    public DieState die;

    public float detectRadius = 8f;
    public bool tutorialMode; //enemies will not change states (forever idle *Sadge*)
    public bool keyTarget; //enemies will target key object first, player will be attacked only as a response (tower-defence-ish)
    public Entity target;
    public bool attacksOnDistance; //Shoots instead of melee


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
        
        die = new DieState(this, stateMachine);

        stateMachine.Initialize(idle);

        if (keyTarget)
            target = FindObjectOfType<EnemyObjective>();
    }


    private void Update() {
        stateMachine.CurrentState.LogicUpdate();

        if ((stateMachine.CurrentState == idle)||(stateMachine.CurrentState == patrol))
        {
            if (!keyTarget) // Attacking player
            {
                if (DoYouLikeWhatYouSee()) // If player is close enough - start chasing them
                {
                    stateMachine.ChangeState(chase);
                }
            }
 
        }
    }
    private bool DoYouLikeWhatYouSee() //Is player close enough
    {
        if (Vector3.Distance(transform.position, stateMachine.player.transform.position) < detectRadius)
        {
            return true;
        }
        return false;
    }
    private void FixedUpdate() {
        stateMachine.CurrentState.PhysicsUpdate();
    }


    public override void GetDamage(int dmgValue,float dmgMod, Vector3 point)
    {
        if (stateMachine.CurrentState == damaged) return;
        if (stateMachine.CurrentState == die) return;
        if (dmgMod == 0) return;

        base.GetDamage(dmgValue, dmgMod, point);
        
        //Vector3 pushVector = Vector3.up;
        Vector3 pushVector = (gameObject.transform.position - point).normalized;

        if (pushVector == Vector3.zero)
            pushVector = (gameObject.transform.position - stateMachine.player.transform.position).normalized;
        
        if (GetHealth() <= 0) //Dead
        {
          rb.isKinematic = false;
          rb.useGravity = true;
          rb.constraints = RigidbodyConstraints.None;
          rb.AddForce(pushVector * 15f * rb.mass * dmgMod, ForceMode.Impulse);
          rb.AddTorque(pushVector * 15f * rb.mass * dmgMod, ForceMode.Impulse);
          stateMachine.ChangeState(die);
        }
        else
        {
            rb.isKinematic = false;
            rb.AddForce(pushVector * 10f * rb.mass * dmgMod, ForceMode.Impulse);
            rb.AddTorque(pushVector * 10f * rb.mass * dmgMod, ForceMode.Impulse);
            stateMachine.ChangeState(damaged);
        }

        

    }
    public void ReceiveStopEvent(string letter) 
    {
        stateMachine.CurrentState.GetStopEvent(letter);
    }

    public void TimeToDie()
    {
        Destroy(this.gameObject);
    }
}
