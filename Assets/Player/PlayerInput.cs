using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void del_Attack();


public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    KeyCode inputKeyValue;
    PlayerAttack playerAttack;


    public del_Attack del_Attack;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            del_Attack();
    }
}
