using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

    private GameObject myUI;

    private string myKiller;
    private CapsuleCollider myCapsuleCollider;
    private Rigidbody myRigidbody;

    private void Start()
    {
        playerInput = playerInput = gameObject.GetComponent<PlayerInput>();
        staminaState = GameObject.FindWithTag("StaminaState").gameObject.GetComponent<Slider>();
        playerRigidBody = gameObject.GetComponent<Rigidbody>();
        playerInput.del_Run = Run;
        playerInput.del_Stop = RunStop;

        myUI = FindObjectOfType<UIManager>().gameObject;
        myCapsuleCollider = gameObject.GetComponent<CapsuleCollider>();
        myRigidbody = gameObject.GetComponent<Rigidbody>();
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
        Destroy(transform.GetChild(0).gameObject);
        Destroy(transform.GetChild(2).gameObject);

        myRigidbody.useGravity = false;
        myCapsuleCollider.enabled = false;
        //Destroy(gameObject);

        if (photonView.IsMine)
        {
            myUI.GetComponent<UIManager>().ShowDeadLogo(myKiller);
            Invoke("SetDestroy", 1.5f);
        }
        //Invoke("SetDestroy", 2.5f);
    }

    public void SetDestroy()
    {
        Destroy(gameObject);
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("StartScene");
    }


    IEnumerator MoveScene()
    {
        
        Debug.Log("Logo Done");
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        Debug.Log("Start moveScene");
        
    }

    [PunRPC]
    public void KillLogo(string name)
    {
        myKiller = name;
        Debug.Log("Get " + name);
    }
}
