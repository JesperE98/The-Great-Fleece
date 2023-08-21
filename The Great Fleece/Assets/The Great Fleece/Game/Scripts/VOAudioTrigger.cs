using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VOAudioTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip clipToPlay;
    [SerializeField] private GameObject _voiceOverTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioManager.Instance.PlayVoiceOver(clipToPlay);
            _voiceOverTrigger.SetActive(false);
        }     
    }
}
