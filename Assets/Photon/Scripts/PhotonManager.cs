using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI nikName = null;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("#############OnConnectedToMaster");
        nikName.text = PhotonNetwork.NickName;
    }




    private void OnGUI()
    {
        GUIStyle gUIStyle = new GUIStyle(GUI.skin.label);
        gUIStyle.fontSize = 20;
        gUIStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(0f, 0f, 350f, 50f), "ServeState : " + PhotonNetwork.Server.ToString(), gUIStyle);
    }
}
