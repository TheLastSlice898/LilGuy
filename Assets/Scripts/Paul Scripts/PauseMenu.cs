using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pause; 

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }


    //MainMenu Button 
    public void BackToMain()
    {
        SceneManager.LoadScene("Main Menu");
    }

    
    //Play button 
    public void Play()
    {
        pause.SetActive(false);
    }

    
    //pause
    public void Pause()
    {
        pause.SetActive(true);
    }
}
