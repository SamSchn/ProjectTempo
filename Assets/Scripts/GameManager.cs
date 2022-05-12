using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    //implemement the singleton pattern
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //set max frame rate so the cpu doesnt go crazy(I think)
        Application.targetFrameRate = 60;
    }

    public void ChangeToMenu()
    {
        SceneManager.LoadScene("Menu");
        PlayerManager._instance.GetComponent<SyncedInput>().ResetInput();// start the synced input over
    }

    public void ChangeToLevelSelector()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    public void ChangeToShop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void LevelOne()
    {
        SceneManager.LoadScene("LevelOne");
        PlayerManager._instance.GetComponent<SyncedInput>().ResetInput();// start the synced input over
    }

    public void ChangeToDeathScreen()
    {
        SceneManager.LoadScene("DeathScreen");
    }

    public void ChangeToWinScreen()
    {
        SceneManager.LoadScene("WinScreen");
    }

    public void ChangeToInstruction()
    {
        SceneManager.LoadScene("Instruction");
    }

    //called when menu button is clicked
    public void OnExitClick()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        // set the PlayMode to stop
        #else
         Application.Quit();
        #endif

    }

}
