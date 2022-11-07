using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public delegate void del_Attack();
public delegate void del_Run();
public delegate void del_stop();


public class PlayerInput : MonoBehaviourPun
{
    [SerializeField]
    KeyCode inputKeyValue;
    PlayerAttack playerAttack;

    public del_Attack del_Attack;
    public del_Attack del_Run;
    public del_Run del_Stop;    

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine) return;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            AudioManagers.Instance.FX(AudioManagers.Instance.Attack);
            del_Attack();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
            del_Run();
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            del_Stop();
    }
}
