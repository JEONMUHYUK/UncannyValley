using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI nikName = null;
    [SerializeField] private Image roomPanel = null;
    [SerializeField] private Image playerImageInRoom = null;
    [SerializeField] private Sprite[] sprites = null;

    private void Awake()
    {
        if (PhotonNetwork.IsMasterClient)
            PhotonNetwork.AutomaticallySyncScene = true;

    }
    void Start() => PhotonNetwork.ConnectUsingSettings();


    public override void OnConnectedToMaster()
    {
        nikName.text = "Player : " + PhotonNetwork.NickName;
        OnRandomJoin();
    }

    
    public override void OnJoinedRoom()
    {
        roomPanel.gameObject.SetActive(true);
        int players = PhotonNetwork.CurrentRoom.PlayerCount;

        for (int i = 0; i < players; i++)
        {
            Image playerImage = PlayerImagePool.Instance.Get(Vector3.zero).GetComponent<Image>();
            playerImage.transform.parent = roomPanel.transform;
            playerImage.sprite = sprites[spriteIdx];
            spriteIdx++;
        }
        AudioManagers.Instance.FX(AudioManagers.Instance.EnterRoom);
    }
    int spriteIdx = 0;
    // 플레이어가 방에 입장시 정보 업데이트
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Image[] childs = roomPanel.gameObject.GetComponentsInChildren<Image>();
        if (childs.Length > 1)
        {
            for (int i = 1; i < childs.Length; i++)
            {
                PlayerImagePool.Instance.Release(childs[i].gameObject);
            }
            spriteIdx = 0;
        }

        int players = PhotonNetwork.CurrentRoom.PlayerCount;
        for (int i = 0; i < players; i++)
        {
            Image playerImage = PlayerImagePool.Instance.Get(Vector3.zero).GetComponent<Image>();
            playerImage.transform.parent = roomPanel.transform;
            playerImage.sprite = sprites[spriteIdx];
            spriteIdx++;
        }

        Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);
        if (PhotonNetwork.CurrentRoom.PlayerCount == 4)
        {
            Debug.Log("다같이 이동!");
            if (PhotonNetwork.IsMasterClient) PhotonNetwork.LoadLevel("GameScene");

        }
        AudioManagers.Instance.FX(AudioManagers.Instance.EnterRoom);
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Image[] childs = roomPanel.gameObject.GetComponentsInChildren<Image>();
        if (childs.Length > 1)
        {
            for (int i = 1; i < childs.Length; i++)
            {
                PlayerImagePool.Instance.Release(childs[i].gameObject);
            }
            spriteIdx = 0;
        }

        int players = PhotonNetwork.CurrentRoom.PlayerCount;
        for (int i = 0; i < players; i++)
        {
            Image playerImage = PlayerImagePool.Instance.Get(Vector3.zero).GetComponent<Image>();
            playerImage.transform.parent = roomPanel.transform;
            playerImage.sprite = sprites[spriteIdx];
            spriteIdx++;
        }
        AudioManagers.Instance.FX(AudioManagers.Instance.LeftRoom);

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
