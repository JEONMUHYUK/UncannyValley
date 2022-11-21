using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerAttack : MonoBehaviourPun
{
    [SerializeField]
    private GameObject myNose;
    private NoseFunction myNoseFunc;
    [SerializeField]
    private float attackSpeed = 2;

    private PlayerInput playerInput;
    private Vector3 attackPos = -Vector3.up;
    private bool attacking = false;

    private void Start()
    {
        if (photonView.IsMine) gameObject.tag = "MainPlayer";
        else gameObject.tag = "Player";

        playerInput = gameObject.GetComponent<PlayerInput>();   
        playerInput.del_Attack = NoseAttack;

        myNoseFunc = myNose.GetComponent<NoseFunction>();
    }
    
    public void NoseAttack()
    {
        gameObject.GetPhotonView().RPC("AttackStart", RpcTarget.All);
    }

    [PunRPC]
    public void AttackStart()
    {
        if (!photonView.IsMine) return;
        if (attacking) return;
        myNoseFunc.HitAble(true);
        photonView.StartCoroutine(NoseFoward());
    }


    [PunRPC]
    IEnumerator NoseFoward()
    {
        attacking = true;
        while (true)
        {
            myNose.transform.Translate(attackPos * Time.deltaTime * attackSpeed);
            yield return null;
            if (Vector3.Distance(myNose.transform.position, gameObject.transform.position) > 0.9) break;
        }
        photonView.StartCoroutine(NoseBack());
        yield break;
    }
    [PunRPC]
    IEnumerator NoseBack()
    {
        while (true)
        {
            myNose.transform.Translate(-attackPos * Time.deltaTime * attackSpeed);
            yield return null;
            if (Vector3.Distance(myNose.transform.position, gameObject.transform.position) < 0.1f) break;
        }
        attacking = false;
        myNoseFunc.HitAble(false);
        yield break;
    }
}
