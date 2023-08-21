using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCutsceneActivation : MonoBehaviour
{
    [SerializeField] private GameObject _cutscene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && GameManager.Instance.HasCard == true)
        {
            _cutscene.SetActive(true);
        }
        else
        {
            print("Darren does not have the key card");
        }
    }
}
