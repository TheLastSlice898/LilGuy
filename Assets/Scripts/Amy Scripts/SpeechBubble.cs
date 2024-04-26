using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpeechBubble : MonoBehaviour
{
    public string level;  

    public void BubbleTeleport()
      {
         SceneManager.LoadScene(level);
      }
 }



