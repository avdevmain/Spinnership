using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Camera cam;
    [SerializeField] private Rigidbody rb;

    public float pogreshnost;

    public float speed;

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
        if (Input.GetKey(KeyCode.Mouse0))
        {
            FollowTheMouse();
        }
        else 
        {
            Float();
        }

                if (rb.velocity.magnitude > maxSpeed)
                rb.velocity = rb.velocity.normalized * maxSpeed;
    }

    private void FollowTheMouse()
    {
        //No inertia movement
        /*
        var pos = Input.mousePosition;
        pos.z = transform.position.z - Camera.main.transform.position.z;
        pos = Camera.main.ScreenToWorldPoint(pos);
        transform.position = Vector3.MoveTowards(transform.position, pos, moveSpeed * Time.deltaTime); */   

        var pos = Input.mousePosition;
        pos.z = transform.position.z - Camera.main.transform.position.z;
        pos = Camera.main.ScreenToWorldPoint(pos);

        if (Vector3.Distance(pos, transform.position) > pogreshnost)
        {
            var direction = pos - transform.position;
            rb.AddRelativeForce(direction.normalized * speed, ForceMode.Force);

            
        }

    }

    private void Float()
    {
     
        if (transform.position.y < floatPos.y)
        {
            rb.AddForce(Vector3.up * upForce);
            
        }

    }

}
