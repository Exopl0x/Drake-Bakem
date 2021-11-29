using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake_behavior : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float movementSpeed;
    public bool canMove = true;
    void Start(){
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }
    void Update()
    {
        transform.right = playerTransform.position - transform.position;
        if(canMove == true)
        transform.position = Vector2.MoveTowards(this.transform.position, playerTransform.position, movementSpeed * Time.deltaTime);
    }
}
