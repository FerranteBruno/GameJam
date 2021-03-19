using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class resetColider : MonoBehaviour

{

    public GameObject pj;
    public GameObject pr;
    public UnityEngine.UI.Image fadeToBlack;
    public float alfaValueFTB;

    // Start is called before the first frame update
    void Start()
    {
        fadeToBlack.color = new Color(0, 0, 0, 1);/// negro
        alfaValueFTB = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        float alfaValue = Mathf.Lerp(fadeToBlack.color.a, alfaValueFTB, 0.03f);
        fadeToBlack.color = new Color(0, 0, 0, alfaValue);

        if(alfaValue > 0.9 && alfaValueFTB == 1)
        {
            SceneManager.LoadScene("SampleScene");
        }

        if(pj.GetComponent<PlayerHealthManager>().playerCurrentHealth == 0)
        {
            FadeOut();


            StartCoroutine(WaitForSceneLoad());
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Programer" || col.gameObject.tag == "Player")
        {
            /*pj.transform.position = new Vector3(-1300.9f, -50.3f, 0f);
            pr.transform.position = new Vector3(-1320.9f, -50f, 0f);*/

            FadeOut();


            StartCoroutine(WaitForSceneLoad());

        }
    }

    public void FadeOut()
    {
        alfaValueFTB = 1f;
    }

    private IEnumerator WaitForSceneLoad()
    {
        
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("SampleScene");

    }
}
