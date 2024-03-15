using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewScene", menuName = "Data/Scene")]
[System.Serializable]
public class NextScene : ScriptableObject
{
    public List<Sentence> sentences;
    public Sprite backgroundSprite;
    public NextScene nextScene;

    [System.Serializable]
    public struct Sentence
    {
        public string text;
        public Speaker character; 
    }
    
}
