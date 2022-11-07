using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    [SerializeField] int unitCount;
    private int[] playerSetPos;
    Vector3[] startPos;
    Vector3 playerStartPos;
    PhotonView PV;
    

    private void Awake()
    {
        startPos = new Vector3[unitCount];
        playerSetPos = new int[4];

        if (PV.IsMine)
        {
            playerStartPos.x = Random.Range(-120, 120);
            playerStartPos.z = Random.Range(-120, 120);
            playerStartPos.y = 1;
            PhotonNetwork.Instantiate("Player", playerStartPos, Quaternion.identity);
        }

        SetStartPos(); // AI 
    }

    private void Start()
    {
        

        for (int i = 0; i < unitCount; i++) // AI Instance
        {
            GameObject inst = PhotonNetwork.Instantiate("Unit", startPos[i], Quaternion.identity);
        }
    }


    public void SetStartPos()
    {
        for (int i = 0; i < startPos.Length; i++)
        {
            startPos[i].x = Random.Range(-120, 120);
            startPos[i].z = Random.Range(-120, 120);
            // if pos as same as playerPos
            if (Mathf.Abs(startPos[i].x - playerStartPos.x) < 1 && Mathf.Abs(startPos[i].z - playerStartPos.z) < 1)
            {
                --i;
                continue;
            }
            startPos[i].y = 1;

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