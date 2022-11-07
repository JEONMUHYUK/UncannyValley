using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Unit : MonoBehaviourPun
{
    public void CallDeath()
    {
        photonView.RPC("Death", RpcTarget.All);
    }

    [PunRPC]
    public void Death()
    {
        Destroy(gameObject);
    }
}
