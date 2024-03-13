using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewChooseScene", menuName = "Data/New Choose Scene" )]
[System.Serializable]
public class ChooseScene : NextScene

{
    public List<ChooseLabel> label; 


    [System.Serializable]
    public struct ChooseLabel
    {
        public string text;
        public NextScene nextScene; 

    }
}
