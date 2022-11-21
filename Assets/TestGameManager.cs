using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEditor;

using UnityEngine.SceneManagement;
public class TestGameManager : MonoBehaviour
{
    [SerializeField] int unitCount;
    [SerializeField] GameObject aiMob;
    private Vector3[] playerSetPos;

    Vector3[] startPos;

    int myNum;
    int posIndexNum = 0;
    int playerCount;

    private void Awake()
    {


        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;


        Application.targetFrameRate = 60;

        startPos = new Vector3[unitCount];
        playerSetPos = new Vector3[4];
        SetStartPos();
    }

    private void Start()
    {
        for(int i = 0; i < unitCount; i++)
        {
            Instantiate(aiMob, startPos[i], Quaternion.identity);
        }
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
