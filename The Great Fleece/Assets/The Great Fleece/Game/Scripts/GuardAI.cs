using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class GuardAI : MonoBehaviour
{
    public bool _coinTossed;
    public Vector3 _coinPos;

    private NavMeshAgent _agent;
    private Animator _anim;
    [SerializeField] private List<Transform> _wayPoints = new List<Transform>();
    [SerializeField] private int _currentTarget;

    private bool _reverse;
    private bool _targetReached;
    


    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }


    void Update()
    {
        GuardsMovement();
    }

    private void GuardsMovement()
    {
        if (_wayPoints.Count > 0 && _wayPoints[_currentTarget] != null && _coinTossed == false)
        {

            _agent.SetDestination(_wayPoints[_currentTarget].position);
            float distance = Vector3.Distance(transform.position, _wayPoints[_currentTarget].position);

            if (distance < 1 && (_currentTarget == 0 || _currentTarget ==  _wayPoints.Count -1))
            {
                _anim.SetBool("Walk", false);
            }
            else
            {
                _anim.SetBool("Walk", true);
            }



            if (distance < 1.0f && _targetReached == false)
            {
                if (_wayPoints.Count < 2)
                {
                    return;
                }
                if ((_currentTarget == 0 ||_currentTarget == _wayPoints.Count -1) && _wayPoints.Count > 1)
                {
                    _targetReached = true;
                    Debug.Log("Target Reached: " + _targetReached);
                    StartCoroutine(WaitBeforeMoving());
                }
                else
                {
                    if (_reverse == true)
                    {
                        _currentTarget--;
                        if (_currentTarget <= 0)
                        {
                            _reverse = false;
                            _currentTarget = 0;
                        }
                    }
                    else
                    {
                        _currentTarget++;
                    }

                }
            }
        }
        else
        {
            float distance = Vector3.Distance(transform.position, _coinPos);

            if (distance < 4.0f)
            {
                _anim.SetBool("Walk", false);
            }
            WaitBeforeMoving();
        }
    }

    IEnumerator WaitBeforeMoving()
    {
        float _randomWaitingTime = Random.Range(2, 6);
        Debug.Log("WaitBeforeMoving()");

        if (_currentTarget == 0 || _currentTarget == _wayPoints.Count - 1)
        {
            yield return new WaitForSeconds(_randomWaitingTime);
            Debug.Log(_randomWaitingTime);
        }

        if (_reverse == true)
        {
            _currentTarget--;

            if (_currentTarget == 0)
            {
                _reverse = false;
                _currentTarget = 0;
            }
        }
        else if (_reverse == false)
        {
            _currentTarget++;

            if (_currentTarget == _wayPoints.Count)
            {
                _reverse = true;
                _currentTarget--;
            }
        }

        _targetReached = false;
    }
}
