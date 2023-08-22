using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] private Image m_progressBar;

    void Start()
    {
        StartCoroutine(LoadLevelAsync());
    }

    IEnumerator LoadLevelAsync()
    {
        AsyncOperation m_operation = SceneManager.LoadSceneAsync(2);

        while(m_operation.isDone == false)
        {
            m_progressBar.fillAmount = m_operation.progress;
            yield return new WaitForEndOfFrame();
        }
    }
}
