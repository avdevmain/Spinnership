using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    private Rigidbody rb;
    public int dmgAmount = 1;
    int layer = 6;

    private void Start() {
        if (rb==null)
        {rb = GetComponent<Rigidbody>();}
    }
 private void OnCollisionEnter(Collision other) {
     if (other.gameObject.layer == layer)
     {
        float power = rb.velocity.magnitude;
        float dmgMod = 1f;
        if (power<1.5f) dmgMod = 0;
        else if (power <6f) dmgMod = 1f;
        else dmgMod = Random.Range(1.2f, 1.55f);
        
        Vector3 touchPoint = Vector3.zero;
        //touchPoint = transform.position;
        touchPoint = other.contacts[0].point;
        
        other.collider.GetComponentInParent<Enemy>().GetDamage(dmgAmount, dmgMod, touchPoint); //push damage receiver in direction opposite to damage dealer

     }
     
 }


 

}
