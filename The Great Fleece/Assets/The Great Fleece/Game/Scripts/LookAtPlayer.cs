using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _cameraStartPosition;

    void Start()
    {
        transform.position = _cameraStartPosition.position;
        transform.rotation = _cameraStartPosition.rotation;
    }

    void Update()
    {
        transform.LookAt(_target);
    }
}
