using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] int unitCount;
    private Vector3[] playerSetPos;
    Vector3[] startPos;
    PhotonView PV;
    int myNum;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        startPos = new Vector3[unitCount];
        playerSetPos = new Vector3[4];
        SetPlayerStartPos();

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
            for (int i = 0; i < 40; i++)
            {
                GameObject player = PhotonNetwork.Instantiate("Unit",new Vector3(Random.Range(-120, 120),1, Random.Range(-120, 120)), Quaternion.identity);
            }
        }
        

        SetStartPos(); // AI 
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
    }

    public void SetPlayerStartPos()
    {
        for (int i = 0; i < 4; i++)
        {
            playerSetPos[i].x = Random.Range(-120, 120);
            playerSetPos[i].z = Random.Range(-120, 120);
            playerSetPos[i].y = 1;
        }
    }

    public void SetStartPos()
    {
        for (int i = 0; i < startPos.Length; i++)
        {
            // if pos as same as playerPos
            for (int j = 0; j < i; j++)
            {
                while (Mathf.Abs(startPos[i].x - playerSetPos[j].x) < 1 && Mathf.Abs(startPos[i].z - playerSetPos[j].z) < 1)
                {
                    startPos[i].x = Random.Range(-120, 120);
                    startPos[i].z = Random.Range(-120, 120);
                }
            }

            startPos[i].y = 1;

            // if pos as same as other Unit pos
            for (int j = 0; j < i; j++)
            {
                while (Mathf.Abs(startPos[i].x - startPos[j].x) < 1 && Mathf.Abs(startPos[i].z - startPos[j].z) < 1)
                {
                    startPos[i].x = Random.Range(-120, 120);
                    startPos[i].z = Random.Range(-120, 120);
                }
            }
        }

    }


}
