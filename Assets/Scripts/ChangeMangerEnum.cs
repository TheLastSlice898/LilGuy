using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMangerEnum : MonoBehaviour
{
    [SerializeField] private SaveSlotObject.Character SelectedCharacter;
    [SerializeField] private SaveSlotObject.Scene SelectedScene;
    public void ChangeEnumCharacter(SaveSlotObject.Character character)
    {
        GameManager.instance.SaveSlotObject.character = character;
    }
    public void ChangeEnumScene(SaveSlotObject.Scene scene)
    {
        GameManager.instance.SaveSlotObject.scene = scene;
    }
    public void ChangeEnums()
    {
        ChangeEnumCharacter(SelectedCharacter);
        ChangeEnumScene(SelectedScene);
    }
}
