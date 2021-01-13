using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    [SerializeField] Transform _checkPoint = default;
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.SetDestination(_checkPoint.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
