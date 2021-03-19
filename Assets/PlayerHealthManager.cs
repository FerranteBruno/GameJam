using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{

    public int playerMaxHealth;
    public int playerCurrentHealth;
    public GameObject BarraVida;
    public Animator animacion;
    
    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        BarraVida = GameObject.Find("Vida");

    }

    // Update is called once per frame
    void Update()
    {
        BarraVida.SendMessage("TakeDamage", playerCurrentHealth);
        if (playerCurrentHealth <= 0)
        {
            animacion.SetBool("Muere", true);
        }
    }

    public void HurtPlayer(int damageToGive)
    {
        playerCurrentHealth -= damageToGive;

        BarraVida.SendMessage("TakeDamage", playerCurrentHealth);
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }

}
