using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShielderController : MonoBehaviour
{

    public float chargeTime = 1;
    public float dischargeTime = 1f;

    public bool Atak;
    public bool fAtak;

    private Rigidbody2D rb2d;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        Atak = false;
        fAtak = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ///anim.ResetTrigger("Atak") ;

    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player")
        {
            //Debug.Log("porquenofuinciona?");
            anim.SetBool("Atak", true);
            //anim.SetBool("Atak", Atak);

        }
        else
        {
            Atak = false;
        }
    }
}