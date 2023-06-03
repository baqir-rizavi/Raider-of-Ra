using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    int index = 0;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        index = PlayerPrefs.GetInt("replayLevel", 0);
    }

    public void OnContinue()
    {
        SceneManager.LoadScene(index);
    }
    public void OnPlay()
    {
        SceneManager.LoadScene(1);
    }
    public void OnReplay()
    {
        SceneManager.LoadScene(index);
    }
    public void OnExit()
    {
        Application.Quit();
    }
    public void OnControl()
    {
        SceneManager.LoadScene(6);
    }
    public void OnMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void OnNextLevel()
    {
        SceneManager.LoadScene(index + 1);
    }
}
