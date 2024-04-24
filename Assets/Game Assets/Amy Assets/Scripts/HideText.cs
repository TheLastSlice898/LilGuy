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
        showText.text = "Press D or A to move, and Space to Jump"; 

        yield return new WaitForSeconds(15); 
        showText.text = "You have learnt movement!"; 

        yield return new WaitForSeconds(20); 
        showText.text = "Did you find the slime creature that waits for you in the forest?"; 

        yield return new WaitForSeconds(27); 
        showText.text = " ";
    }
}

