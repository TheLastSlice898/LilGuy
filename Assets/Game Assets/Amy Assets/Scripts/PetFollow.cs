using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetFollow : MonoBehaviour

{
    public Transform player;  
    public float speed = 5.0f;  
    private bool following = false;
    private Vector2 start;
    public GameObject objectActive;    // object to set active, object to set inactive
    public GameObject objectActive2;  
    public GameObject objectInactive;
    public GameObject objectInactive2;

    void Start()
    {
        start = transform.position;
    }

    void Update()
    {
        if (following)
        {
            Follow();
        }
    }

    void OnTriggerEnter2D(Collider2D other) // when the player enters the box collider the pet follows them
    {
        if (other.CompareTag("Player"))
        {
            following = true;
             objectActive.SetActive(true);
             objectActive2.SetActive(true);
             objectInactive.SetActive(false);
             objectInactive2.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            following = false;
        }
    }

    void Follow()
    {
        Vector2 target = new Vector2(player.position.x, transform.position.y);
        transform.position = Vector2.Lerp(transform.position, target, speed * Time.deltaTime);

        // the pet will rotate with the player movement with consistent scale, Mathf.Abs helps to make any negative numbers positive
        if (player.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
}
