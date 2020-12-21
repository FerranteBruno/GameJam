using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerController>();
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Tierra")
        {
            player.grounded = true;
            Debug.Log("Tiene Contacto"+player.grounded);
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Tierra")
        {
            player.grounded = false;
            Debug.Log("Tiene Contacto" + player.grounded);
        }
    }
}
