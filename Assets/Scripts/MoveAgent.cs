using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAgent : MonoBehaviour
{
    [SerializeField] private List<Transform> wayPoints;

    WayPointGroup wayPointGroup;

    int wayNum = -1;
    public void RandomWayPoint()
    {
        wayNum = Random.Range(0, wayPoints.Count);
    }

    public void TargetDir()
    {
        gameObject.transform.LookAt(wayPoints[wayNum].position);

        gameObject.transform.Translate(gameObject.transform.forward);
    }

    private void Start()
    {
        wayPointGroup = GameObject.FindObjectOfType<WayPointGroup>();
        wayPoints = wayPointGroup.wayPoints;
        RandomWayPoint();
    }

    private void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, wayPoints[wayNum].position) > 0.5)
            TargetDir();
        else
        {
            RandomWayPoint();
        }
    }
}