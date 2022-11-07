using Photon.Pun;
using Photon.Pun.Demo.Cockpit;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScene : MonoBehaviourPunCallbacks
{

    [SerializeField] private TMP_InputField nameFeild = null;
    [SerializeField] private Button startButton = null;
    [SerializeField] private string nikName = null;

    void Start() => Init();

    void Init()
    {
        startButton.onClick.AddListener(delegate { OnclickStartButton(); });
        nameFeild.onValueChanged.AddListener((string name) => { OnInputName(name); });
        AudioManagers.Instance.BGM(AudioManagers.Instance.LobbyBGM);
    }

    void OnclickStartButton()
    {
        if (nikName.Length < 1) return;
        AudioManagers.Instance.FX(AudioManagers.Instance.Click);
        PhotonNetwork.NickName = nikName;
        SceneManager.LoadScene("LobbyScene");
    }

    void OnInputName(string name) => nikName = name;

}
