using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Slice
{
    [CreateAssetMenu(fileName = "SceneCache", menuName = "System/CreateSceneCache", order = 1)]
    public class SceneHolder : ScriptableObject
    {

        public List<string> MenuNames;

        public List<string> sceneNames;
#if UNITY_EDITOR // makes sure that these editor variables and functions are not in the build
        public SceneAsset[] MenuAssets;

        public SceneAsset[] sceneAssets;


    }

    public class Add_Scene : EditorWindow
    {
        [MenuItem("Lil_Guy/Add Scenes to Build Settings")]


        public static void BuildSceneSettings()
        {
            List<EditorBuildSettingsScene> editorBuildSettingsScenes = new List<EditorBuildSettingsScene>();


            var sR = Resources.Load<SceneHolder>("SceneHolder");
            Debug.Log(sR);



            //Add each scene that is inside the Menu Assets Array into the build Settings and makes a new list.
            foreach (var sceneAsset in sR.MenuAssets)
            {
                string scenePath = AssetDatabase.GetAssetPath(sceneAsset);
                Debug.Log($"{scenePath}");
                if (!string.IsNullOrEmpty(scenePath))
                {
                    editorBuildSettingsScenes.Add(new EditorBuildSettingsScene(scenePath, true));
                }
            }
            //Add each scene that is inside the Scene Assets Array into the build Settings and adds to the existing list
            foreach (var sceneAsset in sR.sceneAssets)
            {

                string scenePath = AssetDatabase.GetAssetPath(sceneAsset);
                Debug.Log($"{sceneAsset}");
                if (!string.IsNullOrEmpty(scenePath))
                {
                    editorBuildSettingsScenes.Add(new EditorBuildSettingsScene(scenePath,true));
                }
            }
            EditorBuildSettings.scenes = editorBuildSettingsScenes.ToArray();

        }
        public class BuildSceneNames : EditorWindow
        {

            [MenuItem("Lil_Guy/Add Scene Names")]
            static void BuildNames()
            {
                var sR = Resources.Load<SceneHolder>("SceneHolder");

                List<string> tempMenuNames = new List<string>();
                foreach (SceneAsset MenuAsset in sR.MenuAssets)
                {
                    tempMenuNames.Add(MenuAsset.name);
                }
                sR.MenuNames = tempMenuNames;

                List<string> tempSceneNames = new List<string>();
                foreach (SceneAsset sceneAsset in sR.sceneAssets)
                {
                    tempSceneNames.Add(sceneAsset.name);
                }
                sR.sceneNames = tempSceneNames;
            }
            
        }
#endif // Ends the #UNITY_EDITOR if
    }

}



