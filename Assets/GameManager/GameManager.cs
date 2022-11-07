using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPun
{
    [SerializeField] int unitCount;
    private Vector3[] playerSetPos;
    Vector3[] startPos;
    PhotonView PV;
    

    private void Awake()
    {
        startPos = new Vector3[unitCount];
        playerSetPos = new Vector3[4];


            PhotonNetwork.Instantiate("Player", playerSetPos[0], Quaternion.identity);
        
       


        SetStartPos(); // AI 
    }

    private void Start()
    {
        if (PhotonNetwork.IsMasterClient) // AI add only masterClient
        {
            for (int i = 0; i < unitCount; i++) // AI Instance
            {
                GameObject inst = PhotonNetwork.Instantiate("Unit", startPos[i], Quaternion.identity);
            }
        }
    }

    public void SetPlayerStartPos()
    {
        for(int i = 0; i < 4; i++)
        {
            playerSetPos[i].x = Random.Range(-120, 120);
            playerSetPos[i].z = Random.Range(-120, 120);
            for(int j = 0; j < i; j++)
            {
                if (i != j && Mathf.Abs(playerSetPos[i].x - playerSetPos[j].x) < 1 && Mathf.Abs(playerSetPos[i].z - playerSetPos[j].z) < 1)
                {
                    while (Mathf.Abs(playerSetPos[i].x - playerSetPos[j].x) < 1 && Mathf.Abs(playerSetPos[i].z - playerSetPos[j].z) < 1)
                    {
                        playerSetPos[i].x = Random.Range(-120, 120);
                        playerSetPos[i].z = Random.Range(-120, 120);
                    }
                }
            }
            
            playerSetPos[i].y = 1;


        }
    }

    public void SetStartPos()
    {
        for (int i = 0; i < startPos.Length; i++)
        {
            // if pos as same as playerPos
            for(int j = 0; j < i; j++)
            {
                while(Mathf.Abs(startPos[i].x - playerSetPos[j].x) < 1 && Mathf.Abs(startPos[i].z - playerSetPos[j].z) < 1)
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
