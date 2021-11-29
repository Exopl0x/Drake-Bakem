using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float timeOutLength;

    private float startTime = 0;
    GameObject score;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score");
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

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Cake")
        {
            col.gameObject.SetActive(false);
            score.GetComponent<Score>().score -= 2;
        }
        if (col.gameObject.tag == "Cupcake")
        {
            col.gameObject.SetActive(false);
            score.GetComponent<Score>().score -= 1;
        }
    }
}
