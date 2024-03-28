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
    
    [SerializeField] private string DebugSceneName;
    [SerializeField] private GameObject _pauseMenuOBJ;
    [SerializeField] private GameObject _pauseMenuUI;
    public bool _pauseMenu = false;
    public bool _InMenu = false;

    

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
        if (GetComponent<SaveData>()._saveSlotObject != null)
        {
            GetComponent<SaveData>()._saveSlotObject.UnityScenestring = _currentSceneName;
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
        if (GetComponent<SaveData>()._saveSlotObject != null)
        {
            GetComponent<SaveData>()._saveSlotObject.UnityScenestring = _currentSceneName;
        }
        


#if UNITY_EDITOR
        for (int i = 0; i < SceneHolder.MenuAssets.Length; i++)
        {
            Debug.Log(_currentSceneName);
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