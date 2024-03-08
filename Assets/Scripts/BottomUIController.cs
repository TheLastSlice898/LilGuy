using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class BottomUIController : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI storyText; 
    public TextMeshProUGUI characterNameText;

    private int sentenceIndex = -1; 
    public Scene currentScene;
    private State state = State.Completed;
    public float waitBetweenChar;

    private enum State
    {
        Playing, Completed
    }
    void Start()
    {
        StartCoroutine(TypeText(currentScene.sentences[++sentenceIndex].text));
        characterNameText.text = currentScene.sentences[sentenceIndex].character.whoIsSpeaking;
        characterNameText.color = currentScene.sentences[sentenceIndex].character.textColour; 
    }

    
    private IEnumerator TypeText(string text)
    {
        storyText.text = "";    
        state = State.Playing;
        int wordIndex = 0;

        while (state != State.Completed) 
        {

            storyText.text += text[wordIndex];
            yield return new WaitForSeconds(0.01f* waitBetweenChar); 
            if(++ wordIndex == text.Length)
            {
                state = State.Completed;
                break;
            }

        }
    } 
    
}
