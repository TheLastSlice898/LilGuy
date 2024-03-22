using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
[CreateAssetMenu(fileName = "SceneCache", menuName = "System/CreateSceneCache",order  = 1)]

public class SceneHolder : ScriptableObject
{
    public SceneAsset[] assets;
    // Start is called before the first frame update
}
