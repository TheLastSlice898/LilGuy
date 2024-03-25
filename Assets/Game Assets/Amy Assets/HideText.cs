using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideText : MonoBehaviour
{
    public Text showText; // the text to make appear
    //public int displayTime = 2; // time the text appears for

    void Start()
    {
        StartCoroutine(ChangeText());
    }

    private IEnumerator ChangeText()
    {
        yield return new WaitForSeconds(5); // Wait for delay to end to change text
        showText.text = "Press W or D to move, and Space to Jump"; 

        yield return new WaitForSeconds(15); 
        showText.text = "You have mastered movement!"; 

        yield return new WaitForSeconds(20); 
        showText.text = "A slime creature waits for you somewhere in the forest"; 

        yield return new WaitForSeconds(27); 
        showText.text = " ";
    }
}

