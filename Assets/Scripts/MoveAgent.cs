using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAgent : MonoBehaviour
{

    public List<Transform> wayPoints;
    public int nextIdx = 0;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        var group = GameObject.Find("WayPointGroup");

        if (group != null)
        {
            group.GetComponentsInChildren<Transform>(wayPoints);
            wayPoints.RemoveAt(0);
        }

        MoveWayPoint();
    }

    private void MoveWayPoint()
    {

        if (agent.isPathStale)
        {
            return;
        }

        agent.destination = wayPoints[nextIdx].position;
        agent.isStopped = false;
    }

    private void Update()
    {
        if (agent.remainingDistance <= 0.5f)
        {

            nextIdx = Random.Range(0, wayPoints.Count);

            MoveWayPoint();
        }

    }
}