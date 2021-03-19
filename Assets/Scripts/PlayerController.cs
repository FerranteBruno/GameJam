using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    private Rigidbody2D rb2d;
    private Animator anim;
    public bool grounded;
    public float jumpPower = 20f;
    private bool Jump;
    private bool doubleJump;
    private bool movement = true;
    public bool Ataque;
    public bool Activo;
    public int level=1;
    public AudioSource walkFx;
    public AudioSource Jumpy;
    public AudioSource Jumpy2;
    private SpriteRenderer spr;
    //camara fx
    float magSac;
    public Transform camSac;

    public bool getJump { get => Jump; set => Jump = value; }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        Activo = false;
        anim.SetBool("Waiting", true);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Velocidad", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Ground", grounded);

        if (grounded)
        {
            doubleJump = true;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            if (grounded)
            {
                Jump = true;
                Jumpy.Play();
                doubleJump = true;
            }else if (doubleJump)
            {
                Jump = true;
                Jumpy2.Play();
                doubleJump = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (Activo == true)
            {
                Activo = false;
                rb2d.isKinematic = true;
                anim.SetBool("Waiting", true);
            }
            else
            {
                Activo = true;
                rb2d.isKinematic = false;
                anim.SetBool("Waiting", false);
            }
        }

    }
    void FixedUpdate()
    {
        if (Activo)
        {
            Vector3 fixedVelocity = rb2d.velocity;
            fixedVelocity.x *= 0.85f;//Simula fuerza de arrastre

            if (grounded)//aplica si esta en el suelo
            {
                rb2d.velocity = fixedVelocity;
            }

            float h = Input.GetAxis("Horizontal");

            if (!movement) h = 0;

            walkFx.Play();

            rb2d.AddForce(Vector2.right * speed * h);

            float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
            rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

            if (h > 0.1f)//se mueve a la derecha 
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
            if (h < -0.1f)//se mueve a la izquierda
            {
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
            if (Jump)//salta
            {
                rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                Jump = false;
            }
        }
        else
        {
            Vector3 fixedVelocity = rb2d.velocity;
            fixedVelocity.x *= 0f;
            if (grounded)//aplica si esta en el suelo
            {
                rb2d.velocity = fixedVelocity;
            }
        }

        ///rotacion de camara para daño
        if (magSac > 0.01f)
        {
            camSac.rotation = Quaternion.Euler(
                Random.Range(-magSac, magSac),
                Random.Range(-magSac, magSac),
                Random.Range(-magSac, magSac));
            magSac *= 0.9f;
        }

        //Debug.Log(rb2d.velocity.x);
    }
    public void EnemyJump(float enemyPosX)
    {
        Jump = true;
        movement = false;
        Invoke("EnableMovement", 0.5f);
        spr.color = Color.red;
    }


    public void EnemyKnockBack(float enemyPosX)
    {
        ///Jump = true;

        float side = Mathf.Sign(enemyPosX - transform.position.x);
        rb2d.AddForce(Vector2.left * side * jumpPower, ForceMode2D.Impulse);
        rb2d.AddForce(Vector2.up * jumpPower/2.5f, ForceMode2D.Impulse);
        // rb2d.AddForce(Vector2.left *  jumpPower, ForceMode2D.Force);
        sacudirCamara(0.5f);//sacudon 
        movement = false;
        Invoke("EnableMovement", 0.5f);
        spr.color = Color.red;
    }
    
    void EnableMovement()
    {
        movement = true;
        spr.color = Color.white;
    }
    void sacudirCamara(float MaxSac)
    {
        magSac = MaxSac;
    }

}
