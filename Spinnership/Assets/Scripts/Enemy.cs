using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public int attackPower;
    public StateMachine stateMachine;

    public AnimationCurve MoveCurve;  
    public IdleState idle;
    public PatrolState patrol;
    public ChaseState chase;
    public AttackState attack;
    public ReloadState reload;
    public DamagedState damaged;
    

    public override void GetDamage(int dmgValue,float dmgMod, Vector3 point)
    {
        if (stateMachine.CurrentState == damaged) return;

        base.GetDamage(dmgValue, dmgMod, point);
        
        //Vector3 pushVector = Vector3.up;
        Vector3 pushVector = (gameObject.transform.position - point).normalized;

        if (pushVector == Vector3.zero)
            pushVector = (gameObject.transform.position - stateMachine.player.transform.position).normalized;
        

        Debug.Log(pushVector);
        if (GetHealth() <= 0) //Dead
        {
          rb.isKinematic = false;
          rb.useGravity = true;
          rb.constraints = RigidbodyConstraints.None;
          rb.AddForce(pushVector * 20f * rb.mass * dmgMod, ForceMode.Impulse);
          rb.AddTorque(pushVector * 15f * rb.mass * dmgMod, ForceMode.Impulse);
        }
        else
        {
            rb.isKinematic = false;
            rb.AddForce(pushVector * 10f * rb.mass * dmgMod, ForceMode.Impulse);
            rb.AddTorque(pushVector * 10f * rb.mass * dmgMod, ForceMode.Impulse);
        }

        stateMachine.ChangeState(damaged);

    }
    public void ReceiveStopEvent() 
    {
        stateMachine.CurrentState.GetStopEvent();
    }

    public void TimeToDie()
    {
        Destroy(gameObject);
    }
}
