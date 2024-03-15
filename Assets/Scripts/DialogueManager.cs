using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textDialogue;
    public string[] lines;
    public float speed;

    private int index;
    

   
    void Start()
    {
       textDialogue.text = string.Empty;
       StartDialogue(); 
    }


    void Update()
    {
        
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(Sentence());
        
    }

    IEnumerator Sentence()
    {
        //This lets us type out each line at time 

        foreach (char c in lines[index].ToCharArray()) 
        {

            textDialogue.text += c; 
            yield return new WaitForSeconds(speed);
        }
    }
}
