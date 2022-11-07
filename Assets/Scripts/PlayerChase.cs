using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerChase : MonoBehaviour
{

    private Transform EnemyTr;
    private Transform PlayerTr;
    private NavMeshAgent nvAgent;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Update()
    {
        EnemyTr = gameObject.GetComponent<Transform>();
        PlayerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();

        nvAgent = gameObject.GetComponent<NavMeshAgent>();

        nvAgent.destination = PlayerTr.position;
    }


}
