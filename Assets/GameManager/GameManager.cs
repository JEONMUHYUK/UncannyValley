using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEditor;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] int unitCount;
    [SerializeField] Image winLogo;
    private Vector3[] playerSetPos;

    Vector3[] startPos;
    PhotonView PV;
    int myNum;
    int posIndexNum = 0;
    int playerCount;

    private void Awake()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.AutomaticallySyncScene=false;
        }


        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;


        Application.targetFrameRate = 60;

        startPos = new Vector3[unitCount];
        playerSetPos = new Vector3[4];
        SetStartPos();
        Player[] sortedPlayers = PhotonNetwork.PlayerList;
        for (int i = 0; i < sortedPlayers.Length; i++)
        {
            if (sortedPlayers[i].NickName == PhotonNetwork.NickName)
            {
                myNum = i;
            }
        }
        if (myNum == 0)
        {
            GameObject player = PhotonNetwork.Instantiate("Player", playerSetPos[0], Quaternion.identity);
        }
        if (myNum == 1)
        {
            GameObject player = PhotonNetwork.Instantiate("Player", playerSetPos[1], Quaternion.identity);
        }
        if (myNum == 2)
        {
            GameObject player = PhotonNetwork.Instantiate("Player", playerSetPos[2], Quaternion.identity);
        }
        if (myNum == 3)
        {
            GameObject player = PhotonNetwork.Instantiate("Player", playerSetPos[3], Quaternion.identity);
        }
        if (PhotonNetwork.IsMasterClient)
        {
            for (int i = 0; i < unitCount; i++)
            {
                GameObject player = PhotonNetwork.Instantiate("Unit", startPos[i], Quaternion.identity * Quaternion.Euler(0, Random.Range(0, 360), 0));
            }
        }



        /*if (PhotonNetwork.IsMasterClient)
            photonView.RPC("AiInit", RpcTarget.MasterClient);*/

    }
    //생성할때  //풀링전에 생성을 한다 (매니저)
    [PunRPC]
    [System.Obsolete]
    public void AiInit()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            for (int i = 0; i < unitCount; i++)
            {
                GameObject player = PhotonNetwork.InstantiateSceneObject("Unit", startPos[i], Quaternion.identity * Quaternion.Euler(0, Random.Range(0, 360), 0));
            }
        }
    }


    private void Start()
    {
        winLogo.gameObject.SetActive(false);
        AudioManagers.Instance.BGM(AudioManagers.Instance.GameBgm);
    }


    public override void OnPlayerLeftRoom(Player other)
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            Debug.Log("win");
            Winner();
        }
    }
    public void Winner()
    {
        winLogo.gameObject.SetActive(true);


    }
    IEnumerator WinEff()
    {
        int count = 0;
        while (count < 4)
        {
            winLogo.gameObject.transform.position += Vector3.up;
            yield return new WaitForSeconds(0.5f);
            winLogo.gameObject.transform.position -= Vector3.up;
            yield return new WaitForSeconds(0.5f);
            count++;
        }
        PhotonNetwork.LeaveRoom();
    }


    List<Vector3> check;

    public void SetStartPos()
    {
        check = new List<Vector3>();

        for (int i = 0; i < 4; i++) // Player
        {
            playerSetPos[i].x = Random.Range(-48, 48);
            playerSetPos[i].z = Random.Range(-48, 48);
            playerSetPos[i].y = 0.6f;

            if (!check.Contains(playerSetPos[i]))
                check.Add(playerSetPos[i]);
            else
            {
                i--;
            }
        }

        for (int i = 0; i < startPos.Length; i++)
        {
            startPos[i].x = Random.Range(-48, 48);
            startPos[i].z = Random.Range(-48, 48);
            startPos[i].y = 0.6f;

            if (!check.Contains(startPos[i]))
                check.Add(startPos[i]);

            else
            {
                i--;
                Debug.Log("겹침");
            }
        }
    }
}
