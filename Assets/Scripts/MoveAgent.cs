using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAgent : MonoBehaviour
{

    public List<Transform> wayPoints;
    public int nextIdx = 0;
    private NavMeshAgent agent;

    private void OnEnable()
    {
        Vector3 desiredPos = new Vector3(transform.position.x, 2f, transform.position.z);
        transform.position= desiredPos;
        agent = GetComponent<NavMeshAgent>();
        agent.transform.position = desiredPos;
        agent.autoBraking = false;

        var group = GameObject.Find("WayPointGroup");

        if (group != null)
        {
            group.GetComponentsInChildren<Transform>(wayPoints);
            wayPoints.RemoveAt(0);
        }
        nextIdx = Random.Range(0, wayPoints.Count);
        MoveWayPoint();
    }

    private void MoveWayPoint()
    {
        if (agent.isPathStale)
        {
            return;
        }
        agent.destination = wayPoints[nextIdx].position;
        //agent.isStopped = false;
    }

    private void Update()
    {
        float desiredDistance = Vector3.Distance(agent.destination, transform.position);
        if (desiredDistance <= 2f)
        {
            nextIdx = Random.Range(0, wayPoints.Count);

            MoveWayPoint();
        }

    }
}