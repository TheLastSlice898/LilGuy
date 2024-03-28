using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveSlotSystem : MonoBehaviour
{
    public SaveSlotObject _slotObject;
    public bool _isSaveDataValid;
    [SerializeField] private GameObject SaveSlots;
    [SerializeField] private GameObject ActiveSlot;
    [SerializeField] private GameObject EmptySlot;
    private void Awake()
    {
        SaveSlots = gameObject.transform.parent.gameObject;
        foreach (var SaveSlot in SaveSlots.GetComponentsInChildren<SaveSlotSystem>())
        {
#if UNITY_EDITOR
            if (Resources.Load($"SaveSystem/SaveSlot {SaveSlot.name}") != null)
            {
                var CurrentSaveData = (SaveSlotObject)Resources.Load($"SaveSystem/SaveSlot {SaveSlot.name}");
                Debug.Log(CurrentSaveData); 
                SaveSlot._slotObject = CurrentSaveData;
            }
#endif
            if (System.IO.File.Exists(Application.persistentDataPath + $"/SaveSlot {SaveSlot.name}.Json"))
            {
                Debug.LogWarning(Application.persistentDataPath + $"/SaveSlot {SaveSlot.name}.Json");
                string SaveJSON = System.IO.File.ReadAllText(Application.persistentDataPath + $"/SaveSlot {SaveSlot.name}.Json");
                Debug.Log(SaveJSON);
                Debug.Log(SaveSlot._slotObject);

                JsonUtility.FromJsonOverwrite(SaveJSON, SaveSlot._slotObject);
                
            }
        }

    }
    private void Update()
    {
        _isSaveDataValid = !_slotObject.IsUnityNull();
        if (_isSaveDataValid)
        {
            ActiveSlot.SetActive(true);
            EmptySlot.SetActive(false);

            ActiveSlot.GetComponent<SaveSlotData>().Scene.GetComponentInChildren<Image>().sprite = _slotObject.SceneTex;
            ActiveSlot.GetComponent<SaveSlotData>().Character.GetComponentInChildren<Image>().sprite = _slotObject.CharacterTex;

            ActiveSlot.GetComponent<SaveSlotData>().Scene.GetComponent<TextMeshProUGUI>().text = $"Scene : {_slotObject.SceneName}";
            ActiveSlot.GetComponent<SaveSlotData>().Character.GetComponent<TextMeshProUGUI>().text = $"Character : {_slotObject.CharacterName}";
        }
        else
        {
            ActiveSlot.SetActive(false);
            EmptySlot.SetActive(true);
        }
    }

    public void LoadSaveScece()
    {

        SceneManager.LoadScene(_slotObject.UnityScenestring);

    }
    public void CreateNewSave()
    {
        GameManager.instance.GetComponent<SaveData>().CreateSaveDataObject(gameObject.name.ToString());
        _slotObject = GameManager.instance.GetComponent<SaveData>()._saveSlotObject;
        SceneManager.LoadScene( _slotObject.UnityScenestring);
    }
}

