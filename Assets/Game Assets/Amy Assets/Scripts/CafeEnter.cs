using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CafeEnter : MonoBehaviour
{
    public GameObject Active;  
    public GameObject Inactive;  
    public string NewestLevel;

   void Start()
    {
         Inactive.SetActive(false);  
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Active.SetActive(true);  
            Button loadButton = GameObject.Find("EnterCafe").GetComponent<Button>();
             loadButton.onClick.AddListener(OpenLevel);


        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Active.SetActive(false);  

        }
    }

    void OpenLevel()
    {
        SceneManager.LoadScene(NewestLevel);  
    }
}
