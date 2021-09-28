using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Camera cam;
    [SerializeField] private Rigidbody rb;

    public float maxSpeed = 10f;

    Vector3 floatPos;
    
    public float upForce;


    private void Start() {
        floatPos = transform.position; //Enable floating
    }
    private void Update() {

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
           floatPos = transform.position;//Enable floating

        }

    }



    private void FixedUpdate() {
        if (!Input.GetKey(KeyCode.Mouse0))
        {
            Float();
        }

        if (rb.velocity.magnitude > maxSpeed)
            rb.velocity = rb.velocity.normalized * maxSpeed;

        
    }



    private void Float()
    {
     
        if (transform.position.y < floatPos.y)
        {
            rb.AddForce(Vector3.up * upForce);
            
        }

    }

}
