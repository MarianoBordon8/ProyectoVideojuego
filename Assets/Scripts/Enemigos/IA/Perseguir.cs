using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Perseguir : MonoBehaviour
{

    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform target;


    void Update()
    {
        agent.SetDestination(target.position);
    }
}
