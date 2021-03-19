using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerChaser : MonoBehaviour
{
    // Start is called before the first frame update

    public int damageToGive;
    public AudioSource sparks;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    /*void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);

            sparks.Play();
        }
    }*/

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);

            sparks.Play();
        }


    }
}
