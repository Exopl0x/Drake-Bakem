using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FlamethrowerCooking : MonoBehaviour
{

    public CakeStats stats;
    // public GameObject cake; // assigned to the cake and cupcake
    [SerializeField] float maxHitToCook, damage;
    public float currentHits;
    public Sprite cookedCupcake;
    public Score scoreBox;



    // Start is called before the first frame update
    void Start()
    {
        maxHitToCook = stats.cookedHits;
        currentHits = 0.0f;
        damage = stats.damage;
        scoreBox = GameObject.Find("Score").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnParticleCollision(GameObject other)
    {
        TakeDamage(0.1f); // flamethrower damage goes here
        /// increase cake health and UI to show that the cake is now cooked
        if (currentHits >= maxHitToCook)
        {
            gameObject.GetComponent<AudioSource>().Play();
            if (gameObject.tag == "Cupcake")
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = cookedCupcake;
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                gameObject.GetComponent<Cake_behavior>().canMove = false;
                scoreBox.score += 1;
                // gameObject.GetComponent<Transform>()
            }
            else if (gameObject.tag == "Cake")
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = stats.cookedBread;
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                scoreBox.score += 5;
                gameObject.GetComponent<Cake_behavior>().canMove = false;
            }
            StartCoroutine(Delay());
        }
    }


    void TakeDamage(float damage)
    {
        currentHits += damage;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
