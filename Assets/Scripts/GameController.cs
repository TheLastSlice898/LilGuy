using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Scene scene;
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
                    //backgroundController.SwitchImage(currentScene.background);
                }
                else
                {
                    bottomBar.PlayNextSentence();           
                }
                
            }
        }
        
    }
}
