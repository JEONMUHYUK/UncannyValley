using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class AIMove : MonoBehaviourPun,IPunObservable
{
    [SerializeField] enum State { Move, Stop };
    float moveSpeed = 0.3f;
    float rotateSpeed = 5f;
    float randomRange = 0f;

    private Vector3 arrive;
    private Vector3 dir;
    private Quaternion curRot;

    private PhotonView PV;
    
    State state;

    private void Start()
    {
        MoveToArrive();
        StartCoroutine(CheckArrive());
        state = State.Move;

        curRot = Quaternion.LookRotation(dir);
    }

    private void Update()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            if (Vector3.Distance(transform.position, arrive) > 2f)
            {
                state = State.Move;
                dir = arrive - this.transform.position;
                
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), rotateSpeed * Time.deltaTime);
                transform.position = Vector3.Lerp(transform.position, arrive, moveSpeed * Time.deltaTime);
                //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime); 
            }
            else
            {
                state = State.Stop;
                arrive = transform.position;
            }
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            arrive = (Vector3)stream.ReceiveNext();
            curRot = (Quaternion)stream.ReceiveNext();
        }
    }

    void MoveToArrive()
    {
        randomRange = Random.Range(0f, 20f);
        arrive = transform.position + new Vector3(Random.Range(-randomRange,randomRange), 0f, Random.Range(-randomRange,randomRange));
        if (arrive.x < -49 || arrive.z < -49 || arrive.x > 49 || arrive.z > 49)
            MoveToArrive();
    }

    IEnumerator CheckArrive()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 4f));
            rotateSpeed = Random.Range(1f, 8f);
            MoveToArrive();
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            MoveToArrive();
        }
    }

}
