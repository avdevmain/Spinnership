using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    private PlayerMovement movement;


    private void Awake() {
        if (!rb)
            rb = GetComponent<Rigidbody>();
    }
}
