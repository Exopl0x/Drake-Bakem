using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake_behavior : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float movementSpeed;
    

    void Update()
    {
        transform.right = playerTransform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, playerTransform.position, movementSpeed * Time.deltaTime);
    }
}
