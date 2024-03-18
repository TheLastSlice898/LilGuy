using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        

    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("VN_Scene 1");
    }
    public void SceneChange(int levelId)
    {

        //Looks at what level is called and also adds the level id in the build

        string levelName = "Choice " + levelId;
        SceneManager.LoadScene(levelName);
    }

    public void Quit()
    {
        Debug.Log("Bye for now :3");
        Application.Quit();
    }
}




