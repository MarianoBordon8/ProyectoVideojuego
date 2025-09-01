using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrullar : MonoBehaviour
{
    [SerializeField] Transform[] wayPoints;
    [SerializeField] NavMeshAgent agent;
    int currentWayPoint;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (!agent.hasPath)
        {
            ChangeWayPoint();
        }
    }


    void ChangeWayPoint()
    {
        agent.SetDestination(wayPoints[currentWayPoint].position);
        currentWayPoint++;
        if(currentWayPoint >= wayPoints.Length) currentWayPoint = 0;
    }
}
