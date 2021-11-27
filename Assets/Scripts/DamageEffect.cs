using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    [SerializeField] float duration;
    float countdown;

    [SerializeField] Color NormalColor;
    [SerializeField] Color DamagedColor;

    private void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            this.GetComponent<SpriteRenderer>().color = NormalColor;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cake" || collision.gameObject.tag == "Cupcake")
        {
            countdown = duration;
            this.GetComponent<SpriteRenderer>().color = DamagedColor;

            
        }
    }
}
