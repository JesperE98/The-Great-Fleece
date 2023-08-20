using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverCutscene;
    [SerializeField] private Animator _anim;

    Renderer _rend;


    private void Start()
    {
        _rend = GetComponent<MeshRenderer>();
        _anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Color color = new Color(0.69f, 0.2f, 0.2f, 0.04f);
            _rend.material.SetColor("_TintColor", color);
            _anim.enabled = false;
            StartCoroutine(FreezeCameraRoutine());            
        }
    }

    IEnumerator FreezeCameraRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        _gameOverCutscene.SetActive(true);
    }
}
