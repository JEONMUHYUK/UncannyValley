using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private Vector3[] playerPos;

    private void Awake()
    {
        //Frame setting
        Application.targetFrameRate = 60;

        playerPos = new Vector3[4];

        for(int i = 0; i < playerPos.Length; i++)
        {
            playerPos[i].z = Random.Range(-120f, 120f);
            playerPos[i].x = Random.Range(-120f, 120f);
            playerPos[i].y = 1f;

            if(i > 0)
            {

            }
        }
    }

    public Vector3 GetPlayerPos(int num)
    {
        return playerPos[num];
    }


}
