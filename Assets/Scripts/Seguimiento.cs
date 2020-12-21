using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguimiento : MonoBehaviour
{
    private PlayerController player;
    Vector2 Programador;
    public GameObject Robot;
    bool perseguir;
    public int vel;
    void Update()
    {
        if (perseguir)
        {
            transform.position = Vector2.MoveTowards(transform.position, Programador, vel * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, Programador) > 12f|| Vector2.Distance(transform.position, Programador) <= 10f)
        {
            perseguir = false;
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Programador = Robot.transform.position;
            perseguir = true;
        }
    }
}
