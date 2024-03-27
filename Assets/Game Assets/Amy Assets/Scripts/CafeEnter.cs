using UnityEngine;

public class CafeEnter : MonoBehaviour
{
    public GameObject active;  
    public GameObject inactive;  

   void Start()
    {
         inactive.SetActive(false);  
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            active.SetActive(true);  

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            active.SetActive(false);  

        }
    }
}
