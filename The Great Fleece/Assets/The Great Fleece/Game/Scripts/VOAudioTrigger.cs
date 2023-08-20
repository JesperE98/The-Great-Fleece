using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VOAudioTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip _audio;
    [SerializeField] private GameObject _voiceOverTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {           
            AudioSource.PlayClipAtPoint(_audio, Camera.main.transform.position, 0.1f);
            _voiceOverTrigger.SetActive(false);
        }     
    }
}
