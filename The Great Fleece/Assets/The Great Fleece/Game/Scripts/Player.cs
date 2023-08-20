using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private GuardAI _guardAI;
    private NavMeshAgent _agent;
    private Animator _anim;
    private Vector3 _target;

    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] AudioClip _coinSoundEffect;

    private bool _hasThrownCoin;
    
    void Start()
    {
        _guardAI = GetComponent<GuardAI>();
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponentInChildren<Animator>();
        
    }


    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            Ray _rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(_rayOrigin, out hitInfo))
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

        if (Input.GetMouseButtonDown(1) && _hasThrownCoin == false)
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;            
            

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                _anim.SetTrigger("Throw");                
                Instantiate(_coinPrefab, hitInfo.point, Quaternion.identity);
                AudioSource.PlayClipAtPoint(_coinSoundEffect, transform.position);
                _hasThrownCoin = true;
                SendAIToCoinSpot(hitInfo.point);
            }
        }
    }

    void SendAIToCoinSpot(Vector3 coinPos)
    {
        GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");

        foreach (var guard in guards)
        {
            NavMeshAgent currentAgent = guard.GetComponent<NavMeshAgent>();
            GuardAI currentGuard = guard.GetComponent<GuardAI>();
            Animator currentAnim = guard.GetComponent<Animator>();

            currentGuard._coinTossed = true;
            currentAgent.SetDestination(coinPos);
            currentAnim.SetBool("Walk", true);
            currentGuard._coinPos = coinPos;
        }
    }
}
