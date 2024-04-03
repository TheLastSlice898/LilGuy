using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNoJUmp : MonoBehaviour
{
    public float speed = 5f;
  

    private Rigidbody2D cube;

    void Start()
    {
        cube = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Move left and right
        float moveDirection = Input.GetAxis("Horizontal");
        cube.velocity = new Vector2(moveDirection * speed, cube.velocity.y);
    }
}
