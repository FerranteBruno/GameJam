using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpp : MonoBehaviour
{
    private PlayerController player;
    Vector2 Programador;
    public GameObject Robot;
   
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        
    }
}
