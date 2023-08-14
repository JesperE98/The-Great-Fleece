using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{

    [SerializeField] private Transform _camera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            Camera.main.transform.position = _camera.transform.position;
            Camera.main.transform.rotation = _camera.transform.rotation;
        }
    }
}
