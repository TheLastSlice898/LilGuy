using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Slice.SceneHolder SceneHolder;
    public AudioSource AudioSource;
    public SaveSlotObject SaveSlotObject;
    public enum SaveSlot {SaveData0, SaveData1, SaveData2};
    public SaveSlot CurrentSaveSlot;
    private IDataService dataService = new SaveData();
    [SerializeField] private bool IsEncrypted;
    [SerializeField] private string DebugSceneName;
    [SerializeField] private GameObject _pauseMenuOBJ;
    [SerializeField] private GameObject _pauseMenuUI;
    public bool _pauseMenu = false;
    public bool _InMenu = false;
    [SerializeField] private string Savename;

    
    private static GameManager _instance;
    public static GameManager instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        DebugSceneName = SceneManager.GetActiveScene().name;


        if (_InMenu)
        {
            _pauseMenuOBJ.SetActive(false);
        }
        else
        {
            _pauseMenuOBJ.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            _pauseMenu = !_pauseMenu;
        }

        if (_pauseMenu)
        {
            _pauseMenuUI.SetActive(_pauseMenu);
            Time.timeScale = 0f;
        }
        else
        {
            _pauseMenuUI.SetActive(_pauseMenu);
            Time.timeScale = 1.0f;
        }



    }
    public void SaveScene()
    {
        string _currentSceneName = SceneManager.GetActiveScene().name;
        if (!_InMenu)
        {
            SaveSlotObject.UnityScenestring = _currentSceneName;
            if (dataService.SaveData(Savename, SaveSlotObject, (int)CurrentSaveSlot, IsEncrypted))
            {

            }
            else
            {
                Debug.LogError("Could not save file");
            }
        }

        
    }

    public void TogglePause()
    {
        _pauseMenu = !_pauseMenu;
    }
    public void LoadSceneSingle(string Scene)
    {
        SceneManager.LoadScene(Scene, LoadSceneMode.Single);
        _pauseMenu = false;
    }
    public void LoadSceneAsync(string Scene)
    {
        SceneManager.LoadSceneAsync(Scene, LoadSceneMode.Additive);
        
    }
    
    private void OnLevelWasLoaded()
    {
        string _currentSceneName = SceneManager.GetActiveScene().name;
        
        


#if UNITY_EDITOR
        for (int i = 0; i < SceneHolder.MenuAssets.Length; i++)
        {
            
            if (_currentSceneName == SceneHolder.MenuAssets[i].name)
            {
                _InMenu = true;
                break;
            }
            else
            {
                _InMenu = false;
            }
        }
#endif
#if UNITY_STANDALONE
            for (int i = 0; i < SceneHolder.MenuNames.Count; i++)
            {
                
                if (_currentSceneName == SceneHolder.MenuNames[i])
                {
                    _InMenu = true;
                    break;
                }
                else
                {
                    _InMenu = false;
                }
#endif
            }
    }

}