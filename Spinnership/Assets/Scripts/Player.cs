using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    private PlayerMovement movement;
    public PlayerWeapon weapon;

    private Material[] mat;

    [SerializeField]
    private MeshRenderer mrend;
    //green - 55FF00
    //yellow - F3FF00
    //red - FF1800

    private Coroutine timer;

    private void Awake() {
        if (!rb)
            rb = GetComponent<Rigidbody>();

        if (!weapon)
            weapon = transform.GetChild(2).GetComponent<PlayerWeapon>();

            mat = mrend.materials;
    }


    public override void GetDamage(int dmgValue,float dmgMod, Vector3 point)
    {
        base.GetDamage(dmgValue, dmgMod, point);
        rb.AddForce((this.transform.position - point) * 3f * dmgValue * rb.mass, ForceMode.Impulse);
        //rb.AddTorque((this.transform.position - point) * 3f * rb.mass);
        ChangeIndicator();
    }

    private void ChangeIndicator()
    {  
        if (timer == null)
        {
            timer = StartCoroutine(Timer());
        }
        else
        {
            StopCoroutine(timer);
            timer = StartCoroutine(Timer());
        }
        
    }

    private IEnumerator Timer()
    {
        mat[1].color = Color.yellow;
        yield return new WaitForSecondsRealtime(1f);
        mat[1].color = Color.green;
    }

}
