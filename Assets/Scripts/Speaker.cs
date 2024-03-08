using UnityEngine;

[CreateAssetMenu(fileName = "YourCharater", menuName = "Data/Charater")]
[System.Serializable]
public class Speaker : ScriptableObject
{
    public string whoIsSpeaking;
    public Color textColour; 

}
