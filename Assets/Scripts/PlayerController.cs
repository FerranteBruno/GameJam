using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;
    public float maxSpeed = 5f;
    private Rigidbody2D rb2d;
    private Animator anim;
    public bool grounded;
    public float jumpPower = 20f;
    private bool Jump;
    public bool Ataque;
    public bool Activo;
    public int level=1;
    public AudioSource walkFx;

    public bool getJump { get => Jump; set => Jump = value; }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Activo = false;
        anim.SetBool("Waiting", true);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Velocidad", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Ground", grounded);

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded == true)
        {
            Jump = true;
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
                rb2d.isKinematic=false;
                anim.SetBool("Waiting", false);
            }
        } 

    }
    void FixedUpdate()
    {
        if (Activo)
        {
            Vector3 fixedVelocity = rb2d.velocity;
            fixedVelocity.x *= 0.75f;//Simula fuerza de arrastre

            if (grounded)//aplica si esta en el suelo
            {
                rb2d.velocity = fixedVelocity;
            }

            float h = Input.GetAxis("Horizontal");

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
        Debug.Log(rb2d.velocity.x);
    }
    

}
