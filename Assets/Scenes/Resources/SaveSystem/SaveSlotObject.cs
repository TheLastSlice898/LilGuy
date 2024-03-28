using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveData", menuName = "System/Save/CreateSave", order = 1)]
public class SaveSlotObject : ScriptableObject
{
    public enum Character { Wolf, Fox, Sergal }
    public Character characters;
    public Sprite CharacterTex;
    public string CharacterName;
    public enum Scene { Cafe, Forrest }
    public Scene scene;
    public Sprite SceneTex;
    public string SceneName;
    public string UnityScenestring = "VN_Scene 1";



    // Start is called before the first frame update

}
