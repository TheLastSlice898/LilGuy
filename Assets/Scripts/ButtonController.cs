using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public NextScene scene;
    public string buttonOption; 
    public TextMeshProUGUI textMeshPro;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        

    }

    void Update()
    {
        
    }

    public void loadScene()
    {
        SceneManager.LoadScene("VN_Scene 1");
    }

}




