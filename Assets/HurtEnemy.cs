using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{

    public int damageToGive;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /*void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy" )

        {
            
            col.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
        }
    }*/

    void OnCollisionEnter2D(Collision2D coli)
    {

        if (coli.gameObject.tag == "Enemy")
        {
            coli.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
        }
    }
}