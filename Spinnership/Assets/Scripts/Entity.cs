using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    public GameObject hitEffect;
    [SerializeField] private int armor;
    [SerializeField] private int health;

    public float speed;

    public float upForce;

    public Rigidbody rb;

    public Vector3 idlePos;

    public int GetHealth()
    {
        return health;
    }
    public virtual void GetDamage(int dmgValue, float dmgMod, Vector3 point) //Point is position of weapon, that is dealing damage to current entity
    {  
        if (dmgValue == 0) return;

        health -= (dmgValue - armor);

        Instantiate(hitEffect, this.transform.position, new Quaternion(0,0,0,0));

    }


}
