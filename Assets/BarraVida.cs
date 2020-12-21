using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{

    public GameObject charHP;
    float hp;/*, maxHp = 40;*/

    public Image health;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
        public void TakeDamage(int amount)
        {
            //hp = Mathf.Clamp(hp - amount, 0f, maxHp);
            health.transform.localScale = new Vector2(amount/15, 1);

        }
}
