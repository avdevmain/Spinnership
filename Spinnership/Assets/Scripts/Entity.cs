using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    [SerializeField] private int armorPercent;
    [SerializeField] private int health;


    public float speed;

    public float upForce;

    public Rigidbody rb;

    public Vector3 idlePos;

    public IdleState idle;
    public AttackState attack;

}
