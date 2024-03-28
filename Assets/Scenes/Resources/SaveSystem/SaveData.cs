using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    
    public SaveSlotObject _saveSlotObject;
    public void SaveIntoJSON()
    {
        string data = JsonUtility.ToJson(_saveSlotObject);
        System.IO.File.WriteAllText(Application.persistentDataPath + $"/{_saveSlotObject.name}.Json", data);
    }
    public void CreateSaveDataObject(string SaveSlotNumber)
    {
        _saveSlotObject = ScriptableObject.CreateInstance<SaveSlotObject>();
        string path = "Assets/Scenes/Resources/SaveSystem/SaveData.asset";
        string name = $"SaveSlot {SaveSlotNumber}";
        _saveSlotObject.name = name;    
        string data = JsonUtility.ToJson(_saveSlotObject);
        System.IO.File.WriteAllText(Application.persistentDataPath + $"/{name}.Json", data);

        
;
        Debug.Log($"Saved Data @ {path}");
    }

    
}


