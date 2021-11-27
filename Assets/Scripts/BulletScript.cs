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
}
