using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using System.Net.Mail;
using Unity.VisualScripting;

public class BottomUIController : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI storyText; 
    public TextMeshProUGUI characterNameText;

    private int sentenceIndex = -1; 
    private NextScene currentScene;
    private State state = State.Completed;
    public float waitBetweenChar;
    public GameObject Button;

    private enum State
    {
        Playing, Completed
    }

    public void PlayScene(NextScene scene)
    {
        currentScene = scene;
        sentenceIndex = -1;
        PlayNextSentence();
    }
    public void PlayNextSentence()
    {
        StartCoroutine(TypeText(currentScene.sentences[++sentenceIndex].text));
        characterNameText.text = currentScene.sentences[sentenceIndex].character.whoIsSpeaking;
        characterNameText.color = currentScene.sentences[sentenceIndex].character.textColour; 
        state = State.Playing;
    }

    public bool IsCompleted()
    {
        return state == State.Completed;

    }

    public bool IsLastSentence()
    {
        return sentenceIndex + 1 == currentScene.sentences.Count;
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
    
    public void ButtonTime()
    {
        Button.SetActive(false);
    }
}
