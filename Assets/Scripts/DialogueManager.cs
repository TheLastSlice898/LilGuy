using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textDialogue;
    public string[] lines;
    public float speed;
    public GameObject choices;
    public GameObject credits; 

    private int index;
  
    void Start()
    {
       textDialogue.text = string.Empty;
       StartDialogue(); 
    }


    void Update()
    {
        if(Input.GetKeyDown("space") && !GameManager.instance._pauseMenu)   //bella is a wirnkle brain
         {
            if(textDialogue.text == lines[index]) 
            { 
                
                NextLine();
            
            }
            else 
            {
            
                StopAllCoroutines();
                textDialogue.text = lines[index];
                

            }
        
        }
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

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textDialogue.text = string.Empty;
            StartCoroutine(Sentence());

        }
        else
        {
            gameObject.SetActive(false);

            //Enable Choice Button UI
            choices.SetActive(true);
        }

    }

    void EndScene()
    {
        SceneManager.LoadScene("Credits");
    }
}

