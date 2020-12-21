using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject follow;
    public GameObject follow2;
    public Rigidbody2D elrigi;
    public Vector3 prev;
    public Vector3 prev2;
    public Vector2 minCamPos, maxCamPos;


    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (follow.transform.position != prev)
        {
            float posX = follow.transform.position.x;
            float posY = follow.transform.position.y;

            transform.position = new Vector3(
                Mathf.Clamp(posX, minCamPos.x, maxCamPos.x),
                Mathf.Clamp(posY, minCamPos.y, maxCamPos.y),
                transform.position.z);
        }

        else if(follow2.transform.position != prev){

            float posX = follow2.transform.position.x;
            float posY = follow2.transform.position.y;

            transform.position = new Vector3(
                Mathf.Clamp(posX, minCamPos.x, maxCamPos.x),
                Mathf.Clamp(posY, minCamPos.y, maxCamPos.y),
                transform.position.z);

        }

        prev = new Vector3(follow.transform.position.x, follow.transform.position.y, follow.transform.position.z);

    }

}
