using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataService
{
    bool SaveData<T>(string Savename, T data, int slot, bool Encrypted);

    T LoadData<T>(string Savename, int slot, bool Encrypted);

}
