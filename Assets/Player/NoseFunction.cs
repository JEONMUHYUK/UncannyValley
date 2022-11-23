using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NoseFunction : MonoBehaviourPun
{
    bool hitAble = false;
    string myNickName;

    public void Awake()
    {
        myNickName = PhotonNetwork.NickName;
        Debug.Log("awake nick : " + myNickName);
    }

    public void HitAble(bool able)
    {
        hitAble = able;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("--");
        if (other.tag != "MainPlayer" && photonView.IsMine && hitAble)
        {
            // other.gameObject.GetPhotonView().RPC("Death", RpcTarget.All);


            Debug.Log(myNickName);
            if(other.CompareTag("Player"))
            { other.gameObject.GetComponent<PlayerMove>().photonView.RPC("KillLogo", RpcTarget.All, myNickName); }
            

            other.SendMessage("CallDeath", SendMessageOptions.DontRequireReceiver);

            Debug.Log("ªË¡¶");
        }
    }
}