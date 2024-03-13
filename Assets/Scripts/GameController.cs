using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public NextScene scene;
    public BottomUIController bottomBar;

    void Start()
    {
        bottomBar.PlayScene(scene);
    }


    void Update()
    {
        if(Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
        {
            if(bottomBar.IsCompleted())
            {
                if(bottomBar.IsLastSentence())
                {
                    scene = scene.nextScene;
                    bottomBar.PlayScene(scene);
                   
                }
                else
                {
                    bottomBar.PlayNextSentence();           
                }
                
            }
        }
        
    }



}
