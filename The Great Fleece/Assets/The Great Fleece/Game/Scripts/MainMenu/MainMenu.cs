using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class MainMenu : MonoBehaviour
{
    private PlayableDirector m_playableDirector;

    private void Start()
    {
        m_playableDirector = GetComponent<PlayableDirector>();
    }

    public void StartGame()
    {
        m_playableDirector.Play();
        StartCoroutine(WaitForGameToStart());
        SceneManager.LoadScene(1);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitForGameToStart()
    {
        yield return new WaitForSeconds(1.5f);
    }
}
