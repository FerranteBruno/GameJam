using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpLife : MonoBehaviour
{
    private PlayerController player;
    Vector2 Programador;
    public GameObject Robot;
    public int hpMax;
    public AudioSource hpFx;
    public int hpRegen = 20;
    public int hpRef;
    public bool activo;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {

      //  hpMax = col.GetComponent<PlayerHealthManager>().playerMaxHealth;
        hpMax = col.GetComponent<PlayerHealthManager>().playerMaxHealth;
        hpRef = col.GetComponent<PlayerHealthManager>().playerCurrentHealth += hpRegen;

        if (!activo)
        {
            if (hpRef >= hpMax)
            {
                col.GetComponent<PlayerHealthManager>().playerCurrentHealth = hpMax;
                hpFx.Play();
                activo = true;
            }

            else
            {
                col.GetComponent<PlayerHealthManager>().playerCurrentHealth += hpRegen;
                hpFx.Play();


            }
        }
        Destroy(gameObject,0.5f);

    }


}




