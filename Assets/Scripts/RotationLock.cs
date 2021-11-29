using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLock : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //this.GetComponent<Rigidbody2D>().freezeRotation = true;

    }

    private void Update()
    {
        this.transform.position = player.transform.position;
    }
}
