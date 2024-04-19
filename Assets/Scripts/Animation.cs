using Krivodeling.UI.Effects;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Animation : MonoBehaviour
{

    public Animator animator;
    public bool movement = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(movement)
        {
            animator.SetFloat("Speed", 0); 
        }
       else if (Input.GetKeyDown("a")) //&& Input.GetKeyDown("LeftArrow"))
        {
            //Run "Walk Left" 
            animator.SetFloat("Speed", 1);
            animator.SetBool("Left", true);
            
        }
       else if (Input.GetKeyDown("d")) //&& Input.GetKeyDown("RightArrow"))
        {
            //Run "Walk Right"
            animator.SetFloat("Speed", 1);
            animator.SetBool("Left", false);   
            animator.StopPlayback();
        }

        else
        {
            animator.SetFloat("Speed", 0);
        }

    }


  
   
}
