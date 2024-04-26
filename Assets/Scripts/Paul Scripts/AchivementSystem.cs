using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchivementSystem : MonoBehaviour
{
    [SerializeField] private SaveSlotObject.Character character;

    public void UnlockSticker()
    {
        if (character == SaveSlotObject.Character.Zoey)
        {
            GameManager.instance.SaveSlotObject.FinishedZoey = true;
        }
        if (character == SaveSlotObject.Character.Hawk)
        {
            GameManager.instance.SaveSlotObject.FinishedHawk = true;
        }
        if (character == SaveSlotObject.Character.Freya)
        {
            GameManager.instance.SaveSlotObject.FinishedFreya = true;
        }
        if (character == SaveSlotObject.Character.Chai)
        {
            GameManager.instance.SaveSlotObject.FinishedChai = true;
        }

    }

}
