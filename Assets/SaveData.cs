using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    [SerializeField] private SceneData _sceneData;
    [SerializeField] private CharacterData _characterData;
    public void SaveIntoJSON()
    {
        string data = JsonUtility.ToJson(_sceneData);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/SceneData.Json", data);
    }

}
[System.Serializable]
public class SceneData
{
    public string Character;
    public int scenecount;
    
}
[System.Serializable]
public class CharacterData 
{
    public bool evil;
}