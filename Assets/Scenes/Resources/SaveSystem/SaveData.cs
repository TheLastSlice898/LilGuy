using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEditor;
using Newtonsoft.Json;
using UnityEngine;

public class SaveData : IDataService
{
    
   

    bool IDataService.SaveData<T>(string Savename, T data, int slot, bool Encrypted)
    {
        //makes a path that is related to the name of the save and the save slot
        string path = Application.persistentDataPath + Savename + slot.ToString() +".json";


        if (File.Exists(path))
        {
            try
            {
                Debug.Log("Data Exist. Deleing old make new ");
                File.Delete(path);
                using FileStream stream = File.Create(path);
                stream.Close();
                File.WriteAllText(path, JsonConvert.SerializeObject(data));
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError($"Unable to Save data due to : {e.Message} {e.StackTrace}");
                return false;

            }

        }
        else
        {
            try
            {
                Debug.Log("Creative for the fist time lol");
                using FileStream stream = File.Create(path);
                stream.Close();
                File.WriteAllText(path, JsonConvert.SerializeObject(data));
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError($"Unable to Save data due to : {e.Message} {e.StackTrace}");
                return false;
            }
        }
    }
    public T LoadData<T>(string Savename, int slot, bool Encrypted)
    {
        string path = Application.persistentDataPath + Savename + slot.ToString() + ".json";

        if (!File.Exists(path))
        {
            Debug.LogError($"Cannot Load the file @ {path}!!. The fucker no exists");
            throw new FileNotFoundException($"{path} Does not exist)");
        }
        try
        {
            T data = JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
            return data;
        }
        catch (Exception e )
        {
            Debug.LogError($"failed to load data due to : {e.Message}{e.StackTrace}");
            throw e ;
        }
    }
}


