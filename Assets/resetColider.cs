using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetColider : MonoBehaviour
    
{

    public GameObject pj;
    public GameObject pr;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Programer" || col.gameObject.tag == "Player")
        {
            pj.transform.position = new Vector3(-1300.9f, -50.3f, 0f);
            pr.transform.position = new Vector3(-1320.9f, -50f, 0f);

        }
    }
}
