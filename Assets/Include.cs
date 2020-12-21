using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Include : MonoBehaviour
{
    public PlayerController charUP;
    public Animator ani;



    // Start is called before the first frame update
    void Start()
    {
        //charUP = /*GetComponent<PlayerController>();*/
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        ani.SetBool("tok", true);

        Debug.Log("LE PONGO UN LAAAABEEELL "+charUP.level);

        if (col.gameObject.tag == "Player")
        {

            if (charUP.level < 4)
            {
                charUP.level++;
            }
            else
            {
                charUP.level = 3;
            }

        }

        


        Destroy(gameObject);




    }

}
