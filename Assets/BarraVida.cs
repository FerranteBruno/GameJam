using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{

    public GameObject charHP;
    private Transform vida;

    float hp;
    float maxHp = 40;
    float finalHp;

    public Image health;
    // Start is called before the first frame update
    void Start() {
        Transform vida = transform.Find("vidasa");
    }

    // Update is called once per frame
        public void TakeDamage(int amount)
        {
        //hp = Mathf.Clamp(hp - amount, 0f, maxHp);
        hp = amount;
        finalHp = (hp / maxHp);
        if (finalHp >= 1)
        {
            finalHp = 1;
        }

            health.transform.localScale = new Vector2(finalHp, 0.72f);

        }

    /*public void SetSize(float sizeNormalized)
    {
        vida.localScale = new Vector3(sizeNormalized, 1f);
    }*/
}
