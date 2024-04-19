using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; 
    public float power = 5f; 
    public float delay = 1f; //delay jump so player cant jump endlessly into the sky
    private bool jumping = false;
   
   

    private Rigidbody2D cube;
    

    public GameObject PlayerModel;
    private SpriteRenderer spriteRenderer;
    public Animator animator;


    void Start()
    {
        cube = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        // Move left and right
        float moveDirection = Input.GetAxis("Horizontal");
        cube.velocity = new Vector2(moveDirection * speed, cube.velocity.y);

        //Animation 
        if(moveDirection ==0)
        {
            animator.SetFloat("Speed", 0);

        }
        else if(moveDirection != 0) 
        {
            animator.SetFloat("Speed", 1); 
        }
      

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && !jumping)
        {
            StartCoroutine(JumpWithDelay());
        }

        if (moveDirection >= 0)
        {
            PlayerModel.transform.rotation = Quaternion.Euler(new Vector3(0, 0));

        }
        else
        {
            PlayerModel.transform.rotation = Quaternion.Euler(new Vector3(0, 180));

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

    public void flip()
    {
        cube.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        spriteRenderer.flipX = cube .velocity.x > 0f;   
        
    }
}
