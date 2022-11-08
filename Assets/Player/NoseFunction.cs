using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NoseFunction : MonoBehaviourPun
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("--");
        if (other.tag != "MainPlayer"&&photonView.IsMine)
        {
           // other.gameObject.GetPhotonView().RPC("Death", RpcTarget.All);

            other.SendMessage("CallDeath",SendMessageOptions.DontRequireReceiver);
            Debug.Log("ªË¡¶");
        }
    }
}
