using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityEditor;

public class SaveSlotSystem : MonoBehaviour
{
    private IDataService dataService = new SaveData();
    public SaveSlotObject _slotObject;
    public bool _isSaveDataValid;
    [SerializeField] private GameObject SaveSlots;
    [SerializeField] private GameObject ActiveSlot;
    [SerializeField] private GameObject EmptySlot;
    private void Awake()
    {

        {
            string path = Application.persistentDataPath + "/SaveData" + gameObject.name + ".json";


            if (File.Exists(path))
            {

                SaveSlotObject _tempdata = ScriptableObject.CreateInstance<SaveSlotObject>();
                int slot = int.Parse(gameObject.name);
                _tempdata = dataService.LoadData<SaveSlotObject>("/SaveData", slot, false);
                _slotObject = _tempdata;
#if UNITY_EDITOR
                AssetDatabase.CreateAsset(_tempdata, $"Assets/Scenes/Resources/SaveSystem/SaveData{slot}.asset");
                AssetDatabase.Refresh();
#endif
                GameManager.instance.SaveSlotObject = _slotObject;
                GameManager.instance.CurrentSaveSlot = (GameManager.SaveSlot)slot;

            }
            CheckSaveData();

        }

    }
    private void CheckSaveData()
    {
        _isSaveDataValid = !_slotObject.IsUnityNull();
        if (_isSaveDataValid)
        {
            ActiveSlot.SetActive(true);
            EmptySlot.SetActive(false);

            //changes the character sprite and name
            
            Sprite CharacterSprite = Resources.Load<Sprite>($"Sprites/{_slotObject.character}");
            ActiveSlot.GetComponent<SaveSlotData>().Character.GetComponentInChildren<Image>().sprite = CharacterSprite;
            ActiveSlot.GetComponent<SaveSlotData>().Character.GetComponent<TextMeshProUGUI>().text = $"Character : {_slotObject.character}";


            //changes the scene sprite and name
            Sprite SceneSprite = Resources.Load<Sprite>($"Sprites/{_slotObject.scene}");
            ActiveSlot.GetComponent<SaveSlotData>().Scene.GetComponentInChildren<Image>().sprite = SceneSprite;
            ActiveSlot.GetComponent<SaveSlotData>().Scene.GetComponent<TextMeshProUGUI>().text = $"Scene : {_slotObject.scene}";

            foreach (sticker Achivements in ActiveSlot.GetComponent<SaveSlotData>().Achivemnets.GetComponentsInChildren<sticker>())
            {
                if (_slotObject.FinishedChai)
                {
                    if (Achivements.name == "FinishedChai")
                    {
                        Achivements.IsFinished = true;
                    }
                }
                if (_slotObject.FinishedHawk)
                {
                    if (Achivements.name == "FinishedHawk")
                    {
                        Achivements.IsFinished = true;
                    }
                }
                if (_slotObject.FinishedZoey)
                {
                    if (Achivements.name == "FinishedZoey")
                    {
                        Achivements.IsFinished = true;
                    }
                }
                if (_slotObject.FinishedFreya)
                {
                    if (Achivements.name == "FinishedFreya")
                    {
                        Achivements.IsFinished = true;
                    }
                }

            }
            //get Character sprite and name


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
    public void CreateNewSave(int SaveSlot)
    {
        SaveSlotObject _tempobject = ScriptableObject.CreateInstance<SaveSlotObject>();
        _tempobject.name = SaveSlot.ToString();
        GameManager.instance.SaveSlotObject = _tempobject;
        GameManager.instance.CurrentSaveSlot = (GameManager.SaveSlot)SaveSlot;
        GameManager.instance.SaveScene();
        SceneManager.LoadScene(_tempobject.UnityScenestring);
    }
    public void DeleteSave()
    {

        string path = Application.persistentDataPath + "/SaveData" + gameObject.name + ".json";


        if (File.Exists(path))
        {
            File.Delete(path);
            _slotObject = null;
        }
        CheckSaveData();
    }
}

