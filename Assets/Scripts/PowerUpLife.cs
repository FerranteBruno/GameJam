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


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        hpMax = col.gameObject.GetComponent<PlayerHealthManager>().playerMaxHealth;
        hpRef = col.gameObject.GetComponent<PlayerHealthManager>().playerCurrentHealth += hpRegen;

        if(hpRef >= hpMax)
        {
            col.gameObject.GetComponent<PlayerHealthManager>().playerCurrentHealth = hpMax;
        }

        else
        {
            col.gameObject.GetComponent<PlayerHealthManager>().playerCurrentHealth += hpRegen;
        }


        hpFx.Play();

        Destroy(gameObject);

    }


}




