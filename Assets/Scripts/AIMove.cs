using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public class AIMove : MonoBehaviourPun
{
    
    bool isStop = false;
    private NavMeshAgent agent;
    private Vector3 destination;

    private void Start()
    {
        if(PhotonNetwork.IsConnected)
        {
            if(PhotonNetwork.IsMasterClient)
            {
                agent =  GetComponent<NavMeshAgent>();
            }
            else
            {
                GetComponent<NavMeshAgent>().enabled = false;
            }
        }
    }


    IEnumerator Stop()
    {
        isStop = true;
        yield return new WaitForSeconds(Random.Range(0, 5f));
        isStop = false;
    }

}
