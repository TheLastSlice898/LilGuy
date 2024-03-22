using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public SceneHolder SceneHolder;
    public string _currentScene;
    [SerializeField] private GameObject _pauseMenuOBJ;
    [SerializeField] private GameObject _pauseMenuUI;
    public bool _pauseMenu = false;

    private static GameManager _instance;
    public static GameManager instance {  get { return _instance; } }

    private void Awake()
    {
        if ( _instance!= null && _instance != this)
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
        _currentScene = SceneManager.GetActiveScene().name; 
        string _currentSceneName = _currentScene;

        if (_currentSceneName == "Main Menu")
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
    public void TogglePause()
    {
        _pauseMenu = !_pauseMenu;
    }
    public void LoadSceneSingle(int Sceneint)
    {
        SceneManager.LoadScene(SceneHolder.assets[Sceneint].name,LoadSceneMode.Single);
    }
    public void LoadSceneAsync(int Sceneint)
    {
        SceneManager.LoadSceneAsync(SceneHolder.assets[Sceneint].name, LoadSceneMode.Additive);
    }
}
