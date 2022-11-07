using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI nikName = null;
    [SerializeField] private Image roomPanel = null;
    [SerializeField] private Image playerImageInRoom = null;

    Color[] colors = new Color[4] {Color.cyan, Color.blue, Color.gray, Color.red };
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("#############OnConnectedToMaster");
        nikName.text = "Player : " + PhotonNetwork.NickName;
        OnRandomJoin();
    }

    
    public override void OnJoinedRoom()
    {
        roomPanel.gameObject.SetActive(true);
        int players = PhotonNetwork.CurrentRoom.PlayerCount;
        for (int i = 0; i < players; i++)
        {
            Image palyerImage = Instantiate(playerImageInRoom, roomPanel.transform);
            palyerImage.color = colors[colorIdx];
            colorIdx++;
        }
        Debug.Log("OnJoinedRoom");
        
        

        //Debug.Log(playerName.text);
        //playerName.text = PhotonNetwork.NickName;
    }
    int colorIdx = 0;
    // 플레이어가 방에 입장시 정보 업데이트
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Image palyerImage = Instantiate(playerImageInRoom, roomPanel.transform);
        palyerImage.color = colors[colorIdx];
        colorIdx++;

        Debug.Log(newPlayer.NickName);
        if (PhotonNetwork.CurrentRoom.PlayerCount == 4)
        {
            PhotonNetwork.LoadLevel("GameScene");
        }
    }

    public void OnRandomJoin()
    {
        byte expectedMaxPlayers = 0;
        MatchmakingMode matchingType = MatchmakingMode.FillRoom;
        TypedLobby typedLobby = null;
        string sqlLobbyFilter = null;
        string roomName = null;
        string[] expectedUsers = null;

        PhotonNetwork.JoinRandomOrCreateRoom(
            new ExitGames.Client.Photon.Hashtable(),
            expectedMaxPlayers,
            matchingType,
            typedLobby,
            sqlLobbyFilter,
            roomName,
            CreateRoom(),
            expectedUsers
            );
    }

    public RoomOptions CreateRoom()
    { 
        
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        return roomOptions;
    }

    private void OnGUI()
    {
        GUIStyle gUIStyle = new GUIStyle(GUI.skin.label);
        gUIStyle.fontSize = 20;
        gUIStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(0f, 0f, 350f, 50f), "ServeState : " + PhotonNetwork.Server.ToString(), gUIStyle);
    }
}
