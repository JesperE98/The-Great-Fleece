using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UIManager is null!!");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void RestartTheGame()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
