using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{

    public float maxSpeed = 10f;
    public float speed = 10f;
    private Rigidbody2D rb2d;
    public AudioSource Walk;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
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

        else if(speed < 0)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        float yOffset = 0.4f;

        if (col.gameObject.tag == "Player")
        {
            if (transform.position.y + yOffset < col.transform.position.y)
            {
                col.gameObject.SendMessage("EnemyJump");
            }
            else
            {
                col.gameObject.SendMessage("EnemyKnockBack", transform.position.x);
            }
        }
    }
}
