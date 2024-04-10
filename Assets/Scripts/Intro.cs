using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class Intro : MonoBehaviour
{
    public VideoPlayer player;
    
    // Start is called before the first frame update
    void Start() { player.loopPointReached += nextScene; }

    void nextScene(VideoPlayer vp)
    {
        Debug.Log("its jover");
        SceneManager.LoadScene("MainMenu");
    }
}
