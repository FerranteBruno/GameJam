using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparos : MonoBehaviour
{
    public Transform firePoint;
    public GameObject ray_1;
    public GameObject ray_2;
    public GameObject ray_3;

    private PlayerController robot;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        robot = GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && robot.Ataque == false && robot.Activo)
        {
            robot.Ataque = true;

            anim.SetBool("Atak", true);
            Shoot();
        }
        else if (!Input.GetKeyDown(KeyCode.Space))
        {
            robot.Ataque = false;
            anim.SetBool("Atak", false);
        }

    }
    void Shoot()
    {
        Debug.Log("level-Into" + robot.level);
        switch (robot.level)
        {
            case 1:
                Instantiate(ray_1, firePoint.position, firePoint.rotation);
                //Debug.Log("level-1" + robot.level);
                break;
            case 2:
                Instantiate(ray_2, firePoint.position, firePoint.rotation);
                //Debug.Log("level-3" + robot.level);
                break;
            case 3:
                Instantiate(ray_3, firePoint.position, firePoint.rotation);
                ///Debug.Log("level-3" + robot.level);
                break;
            default:
                Instantiate(ray_1, firePoint.position, firePoint.rotation);
                //Debug.Log("level-D" + robot.level);
                break;

        }

    }
}
