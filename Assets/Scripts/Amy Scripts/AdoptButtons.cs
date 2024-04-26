using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 

public class AdoptButtons : MonoBehaviour
{
    public string newlevel;  
    public Button load;  
    public Button exit;  

    void Start()
    {
        load = GameObject.Find("load").GetComponent<Button>();
        exit = GameObject.Find("exit").GetComponent<Button>();
        load.onClick.AddListener(LoadLevel);
        exit.onClick.AddListener(ExitGame);
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(newlevel);  
    }

    void ExitGame()
    //Why did you not adopt the slime :(
    {
        Application.Quit(); 
        Debug.Log("The game has quit. >:( ");
    }
}
