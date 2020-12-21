using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray : MonoBehaviour
{
    private Rigidbody2D MyRb;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        MyRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MyRb.velocity = transform.right * speed;
        Destroy(gameObject, 5f);
    }

}
