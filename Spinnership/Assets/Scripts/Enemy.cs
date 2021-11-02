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
    


    public bool attacksOnDistance; //Shoots instead of melee

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
