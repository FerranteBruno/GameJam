using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valores : MonoBehaviour
{
    private PlayerController player;
    private Rigidbody2D prog_rigibodi;
    public bool grounded;
    public float speed = 2f;
    public float maxSpeed = 5f;
    private Animator animProg;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerController>();
        prog_rigibodi = GetComponentInParent<Rigidbody2D>();
        animProg = GetComponent<Animator>();
        
    }
    void FixedUpdate()
    {
        Vector3 fixedVelocity = prog_rigibodi.velocity;
        fixedVelocity.x *= 0.75f;//Simula fuerza de arrastre

        if (player.grounded)//aplica si esta en el suelo
        {
            prog_rigibodi.velocity = fixedVelocity;
            animProg.SetBool("Ground", true);
        }
        else
        {
            animProg.SetBool("Ground", false);
        }

        float h = Input.GetAxis("Horizontal");

        prog_rigibodi.AddForce(Vector2.right * speed * h);

        float limitedSpeed = Mathf.Clamp(prog_rigibodi.velocity.x, -maxSpeed, maxSpeed);
        prog_rigibodi.velocity = new Vector2(limitedSpeed, prog_rigibodi.velocity.y);

        if (h > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (player.getJump)
        {
            prog_rigibodi.AddForce(Vector2.up * player.jumpPower, ForceMode2D.Impulse);
            player.getJump = false;
        }
    }
}
