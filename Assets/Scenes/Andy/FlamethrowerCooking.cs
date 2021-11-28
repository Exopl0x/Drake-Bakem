using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerCooking : MonoBehaviour
{

    public CakeStats stats;
    // public GameObject cake; // assigned to the cake and cupcake
    [SerializeField] float maxHitToCook, damage;
    public static float currentHits;

    
    // Start is called before the first frame update
    void Start()
    {
        maxHitToCook = stats.cookedHits;
        currentHits = 0.0f;
        damage = stats.damage;
        Debug.Log(maxHitToCook);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnParticleCollision(GameObject other){
       TakeDamage(0.1f); // flamethrower damage goes here
        /// increase cake health and UI to show that the cake is now cooked
        if (currentHits >= maxHitToCook){
            Debug.Log("CONDITION MET KILLING");
            gameObject.SetActive(false);
        }  
    }


    void TakeDamage(float damage){
        currentHits += damage;

    }
}
