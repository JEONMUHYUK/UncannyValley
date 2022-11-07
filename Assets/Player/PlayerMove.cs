using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviourPun
{
    [SerializeField]
    private Rigidbody playerRigidBody;
    [SerializeField]
    private Slider staminaState = null;
    [SerializeField]
    private float moveSpeed = 2;
    [SerializeField]
    private float runSpeed = 1;
    [SerializeField]
    private float stamina = 100;
    [SerializeField]
    private float staminaConsumtion = 0.1f;

    private PlayerInput playerInput;
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotate = Vector3.zero;
    private bool isRun = false;

    private void Start()
    {
        playerInput = playerInput = gameObject.GetComponent<PlayerInput>();
        staminaState = GameObject.FindWithTag("StaminaState").gameObject.GetComponent<Slider>();
        playerRigidBody = gameObject.GetComponent<Rigidbody>();
        playerInput.del_Run = Run;
        playerInput.del_Stop = RunStop;
    }

    private void Update()
    {
        if (!photonView.IsMine) return;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Mouse X");
        staminaState.value = stamina;

        velocity.z = -z;
        velocity.x = -x;
        rotate.y = y;
        playerRigidBody.transform.Rotate(rotate);

        if (!isRun)
        {
            playerRigidBody.transform.Translate(velocity * Time.deltaTime * moveSpeed);
            if (stamina < 100)
                stamina += staminaConsumtion;
            else
                stamina = 100;
        }
        else if (isRun)
        {
            if (stamina > 0)
            {
                stamina -= staminaConsumtion;
                playerRigidBody.transform.Translate(velocity * Time.deltaTime * (moveSpeed + runSpeed));
            }
            else
                playerRigidBody.transform.Translate(velocity * Time.deltaTime * moveSpeed);
        }
    }

    public void Run()
    {
        isRun = true;
    }
    public void RunStop()
    {
        isRun = false;
    }
    public void CallDeath()
    {
        photonView.RPC("Death", RpcTarget.All);
    }
    [PunRPC]
    public void Death()
    {
        AudioManagers.Instance.FX(AudioManagers.Instance.Death);
        Destroy(gameObject);
        if (photonView.IsMine)
            PhotonNetwork.LeaveRoom();
    }
}
