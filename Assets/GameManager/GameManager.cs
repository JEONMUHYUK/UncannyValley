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
    private Vector3[] playerSetPos;
    Vector3[] startPos;
    PhotonView PV;
    int myNum;
    int posIndexNum = 0;

    private void Awake()
    {
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
                GameObject player = PhotonNetwork.Instantiate("Unit", startPos[i], Quaternion.identity * Quaternion.Euler(0,Random.Range(0,360),0));
            }
        }

    }

    private void Start()
    {
        /* if (PhotonNetwork.IsMasterClient) // AI add only masterClient
         {
             for (int i = 0; i < unitCount; i++) // AI Instance
             {
                 GameObject inst = PhotonNetwork.Instantiate("Unit", startPos[i], Quaternion.identity);
             }
         }*/

        AudioManagers.Instance.BGM(AudioManagers.Instance.GameBgm);
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
                Debug.Log("°ãÄ§");
            }
        }
    }
}
