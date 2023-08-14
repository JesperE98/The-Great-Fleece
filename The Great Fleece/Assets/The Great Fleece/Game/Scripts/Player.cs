using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _anim;
    private Vector3 _target;
    
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(_ray, out hitInfo))
            {
                _anim.SetBool("IsWalking", true);
                _agent.SetDestination(hitInfo.point);
                _target = hitInfo.point;
            }
        }

        float _distance = Vector3.Distance(transform.position, _target);

        if (_distance < 1.0f)
        {
            _anim.SetBool("IsWalking", false);

        }
    }
}
