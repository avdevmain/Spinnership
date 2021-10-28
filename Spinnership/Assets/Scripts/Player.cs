using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    private PlayerMovement movement;
    public PlayerWeapon weapon;

    private void Awake() {
        if (!rb)
            rb = GetComponent<Rigidbody>();

        if (!weapon)
            weapon = transform.GetChild(2).GetComponent<PlayerWeapon>();
    }

    public override void GetDamage(int dmgValue,float dmgMod, Vector3 point)
    {
        base.GetDamage(dmgValue, dmgMod, point);
        rb.AddForce((this.transform.position - point) * 3f * dmgValue * rb.mass, ForceMode.Impulse);
        //rb.AddTorque((this.transform.position - point) * 3f * rb.mass);
    }
}
