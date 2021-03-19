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
    public AudioSource Walk;
    public float maxSpeed = 10f;
    public float speed = 10f;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        value = rb2d.position - Enemigo;

        anim.SetFloat("speed", Mathf.Abs(value.x));
       // Debug.Log(rb2d.velocity.x);
    }
    void FixedUpdate()
    {


        if (perseguir)
        {
            rb2d.position = Vector2.MoveTowards(transform.position, Enemigo, vel * Time.deltaTime);
            Walk.Play();

            if (Vector2.Distance(transform.position, Enemigo) > 12f)
            {
                perseguir = false;
            }

            if (value.x < 1.5f)
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
            if (value.x > 1.5f)
            {
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
        }
        else
        {

            rb2d.AddForce(Vector2.right * speed);
            float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
            rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

            Walk.Play();

            if (rb2d.velocity.x < 0.5f && rb2d.velocity.x > -0.5f)
            {
                speed = -speed;
                rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            }

            if (speed > 0)
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }

            else if (speed < 0)
            {
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
        }

    }

    private void OnCollisionStay2D(Collision2D col)
    {
        float yOffset = 0.4f;

        if (col.gameObject.tag == "Player")
        {
            if (transform.position.y + yOffset < col.transform.position.y)
            {
                col.gameObject.SendMessage("EnemyKnockBack", transform.position.x);

            }
            else
            {
                col.gameObject.SendMessage("EnemyKnockBack", transform.position.x);
            }
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
