using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NoseFunction : MonoBehaviourPun
{
    bool hitAble = false;

    public void HitAble(bool able)
    {
        hitAble = able;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("--");
        if (other.tag != "MainPlayer"&&photonView.IsMine && hitAble)
        {
           // other.gameObject.GetPhotonView().RPC("Death", RpcTarget.All);

            other.SendMessage("CallDeath",SendMessageOptions.DontRequireReceiver);
            Debug.Log("ªË¡¶");
        }
    }
}
