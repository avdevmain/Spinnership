using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Player player;
    [SerializeField] private Camera cam;



    
    public float upForce;

    private void Start() {

        if (!player)
            player = GetComponent<Player>();

        player.idlePos = transform.position; //Enable floating
    }
    private void Update() {

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
           player.idlePos = transform.position;//Enable floating

        }

    }



    private void FixedUpdate() {
        if (!Input.GetKey(KeyCode.Mouse0))
        {
            Float();
        }

      //  if (player.rb.velocity.magnitude > maxSpeed)
       //     player.rb.velocity = player.rb.velocity.normalized * maxSpeed;

        
    }



    private void Float()
    {
     
        if (transform.position.y < player.idlePos.y)
        {
            player.rb.AddForce(Vector3.up * player.upForce);   
        }
        else
        {
            player.rb.AddForce(Vector3.up * player.upForce/2);  
        }

    }

}
