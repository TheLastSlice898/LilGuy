using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; 
    public float power = 5f; 
    public float delay = 1f; //delay jump so player cant jump endlessly into the sky
    private bool jumping = false; 

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

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && !jumping)
        {
            StartCoroutine(JumpWithDelay());
        }
    }

    IEnumerator JumpWithDelay() // wait x seconds before letting the player jump again
    {
        jumping = true;
        cube.velocity = new Vector2(cube.velocity.x, power);

        // waits for amount of seconds 
        yield return new WaitForSeconds(delay);

        // set jump to false after the delay
        jumping = false;
    }
}
