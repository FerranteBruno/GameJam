using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Include : MonoBehaviour
{
    public PlayerController charUP;
    public Animator ani;
    public AudioSource pUp;
    public bool activo;



    // Start is called before the first frame update
    void Start()
    {
        //charUP = /*GetComponent<PlayerController>();*/
        ani = GetComponent<Animator>();
        activo = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        ani.SetBool("tok", true);

        Debug.Log("LE PONGO UN LAAAABEEELL "+charUP.level);

        if (!activo)
        {
            if (col.gameObject.tag == "Player")
            {

                if (charUP.level < 4)
                {
                    charUP.level++;
                    pUp.Play();
                    activo = true;
                }
                else
                {
                    charUP.level = 3;
                    pUp.Play();
                    activo = true;
                }

            }
        }
        


        Destroy(gameObject,1.2f);




    }

}
