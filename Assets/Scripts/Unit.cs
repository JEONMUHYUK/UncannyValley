using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Unit : MonoBehaviourPun
{
    [PunRPC]
    public void Death()
    {
        Destroy(gameObject);
    }
}
