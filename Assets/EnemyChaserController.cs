using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaserController : MonoBehaviour
{
    private PlayerController player;
    private Rigidbody2D rb2d;
    private Animator anim;
    Vector2 Enemigo;
    //Vector2 startPos;
    Vector2 value;
    public GameObject Robot;
    bool perseguir;
    public int vel;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        value = rb2d.position - Enemigo;

        anim.SetFloat("speed", Mathf.Abs(value.x));
        Debug.Log(rb2d.velocity.x);
    }
    void FixedUpdate()
    {
        

        if (perseguir)
        {
            rb2d.position = Vector2.MoveTowards(transform.position, Enemigo, vel * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, Enemigo) > 12f)
        {
            perseguir = false;
        }

        if (value.x < 0.1f)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (value.x > 0.1f)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Enemigo = Robot.transform.position;
            perseguir = true;
        }
    }
}
