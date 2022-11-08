using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Unit : MonoBehaviourPun
{
    public void CallDeath()
    {
        AudioManagers.Instance.FX(AudioManagers.Instance.Death);
        photonView.RPC("Death", RpcTarget.All);
    }

    [PunRPC]
    public void Death()
    {
        Destroy(gameObject);
    }
}
