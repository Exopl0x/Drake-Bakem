using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float timeOutLength;

    private float startTime = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        startTime += Time.deltaTime;

        if (startTime >= timeOutLength)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Cake"){
            col.gameObject.SetActive(false);
        }
        if(col.gameObject.tag == "Cupcake"){
            col.gameObject.SetActive(false);
        }
    }
}
