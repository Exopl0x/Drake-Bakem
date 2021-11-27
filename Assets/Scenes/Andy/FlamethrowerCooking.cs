using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerCooking : MonoBehaviour
{

    public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnParticleCollision(GameObject other){
        /// decrease cake health and UI 
        gameObject.SetActive(false);
    }
}
