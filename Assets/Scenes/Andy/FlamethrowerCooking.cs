using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerCooking : MonoBehaviour
{

    public CakeStats stats;
    // public GameObject cake; // assigned to the cake and cupcake
    [SerializeField] int maxHealth, damage;
    int currentHealth;

    
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = stats.health;
        currentHealth = maxHealth;
        damage = stats.damage;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnParticleCollision(GameObject other){
       TakeDamage(5);
        /// decrease cake health and UI 
        if (currentHealth <= 0)
            gameObject.SetActive(false);

       
        
    }
    void TakeDamage(int damage){
        currentHealth -= damage;
    }
}
