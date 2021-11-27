using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake_behavior : MonoBehaviour
{
    [SerializeField] Transform playerPosition;
    [SerializeField] float movementSpeed;

    void Update()
    {
       transform.position = Vector2.MoveTowards(this.transform.position, playerPosition.position, movementSpeed * Time.deltaTime);
    }
}
