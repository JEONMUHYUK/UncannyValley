using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NoseFunction : MonoBehaviourPun
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("--");
        if (other.tag != "MainPlayer")
        {
            other.gameObject.GetPhotonView().RPC("Death", RpcTarget.All);
            Debug.Log("ªË¡¶");
        }
    }

}
