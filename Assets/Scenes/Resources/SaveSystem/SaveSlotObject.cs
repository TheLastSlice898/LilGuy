using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveData", menuName = "System/Save/CreateSave", order = 1)]
public class SaveSlotObject : ScriptableObject
{
    public enum Character { None, Chai, Hawk, Freya, Zoey }
    public Character character;
    //public Sprite CharacterTex;
    public enum Scene { Forest, CafeEXT, CafeINT, CafeBACK }
    public Scene scene;
    //public Sprite SceneTex;
   
    public bool FinishedHawk;
    public bool FinishedChai;
    public bool FinishedFreya;
    public bool FinishedZoey;
    public string UnityScenestring = "ForestScene";

    

    // Start is called before the first frame update

}
