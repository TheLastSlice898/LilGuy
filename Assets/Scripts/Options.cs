using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using Slider = UnityEngine.UI.Slider;

public class Options : MonoBehaviour
{
    public Slider volume;
    public AudioMixer mixer; 

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public void MainVolume()
    {
        //sets the value on the slider, tells it to shut up or be full volume
        mixer.SetFloat("Background", volume.value); 

    }

    public void FullScreen()
    {
        Debug.Log("I am now less full"); 
        Screen.fullScreen = !Screen.fullScreen; 
        
    }
}
