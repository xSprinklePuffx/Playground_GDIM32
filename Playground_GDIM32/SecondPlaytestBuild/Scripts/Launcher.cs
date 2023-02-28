using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using System.Linq;
using UnityEngine.UI;

public class Launcher : MonoBehaviourPunCallbacks
{
    //Script by Jacqueline Hernandez

    //We are going to make this Launcher an instance
    public static Launcher Instance;

    //Serializing a bunch of texts and input fields for our different menus
    [SerializeField] TMP_InputField roomNameInputField;
    [SerializeField] TMP_Text errorText;
    [SerializeField] TMP_Text roomNameText;
    [SerializeField] Transform roomListContent;
    [SerializeField] GameObject roomListItemPrefab;
    /*[SerializeField] GameObject PlayerListItemPrefab;
    [SerializeField] Transform PlayerListContent;*/
    [SerializeField] GameObject startGameButton;

    //Also getting access to items and prefabs in the inspector
    public List<PlayerItem> playerItemsList = new List<PlayerItem>();
    public PlayerItem playerItemPrefab;
    public Transform playerItemParent;

    void Awake()
    {
        Instance = this;
    }

    //We will automatically sync scenes to esnure that all players get spawned into the same scene
    void Start()
    {
        Debug.Log("Connected To Master");
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    //When the player has joined the title menu will be displayed to them
    public override void OnJoinedLobby()
    {
        MenuManager.Instance.OpenMenu("title");
        Debug.Log("Joined Lobby");
    }

    //Here the player can create a room and input a name for it
    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(roomNameInputField.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(roomNameInputField.text, new RoomOptions() { MaxPlayers = 3, BroadcastPropsChangeToAll = true });
        MenuManager.Instance.OpenMenu("Loading");
    }

    //When the player has created a room they will be sent to the room menu where they can select their character & wait for players to join their lobby
    public override void OnJoinedRoom()
    {
        MenuManager.Instance.OpenMenu("Room");
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;

        /*Player[] players = PhotonNetwork.PlayerList;

        foreach(Transform child in PlayerListContent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < players.Count(); i++)
        {
            Instantiate(PlayerListItemPrefab, PlayerListContent).GetComponent<PlayerListItem>().SetUp(players[i]);
        }*/

        UpdatePlayerList();

        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    //Only the start button is visible for the creator of the lobby
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    //Here  we are opening up an error menu just in case there is an error while connecting
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "Room Creation Failed: " + message;
        MenuManager.Instance.OpenMenu("Error");
    }

    //When the host starts the game, the players will be sent to level one
    public void StartGame()
    {
        PhotonNetwork.LoadLevel("LevelOne");
    }

    //The player can leave the room they are in
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuManager.Instance.OpenMenu("Loading");
    }

    //They could also join a room if they are interested
    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
        MenuManager.Instance.OpenMenu("Loading");
    }

    //Once the player leaves the room they will be sent back to the title screen
    public override void OnLeftRoom()
    {
        MenuManager.Instance.OpenMenu("title");
    }

    //This just destroys a lobby if the host has left it
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (Transform trans in roomListContent)
        {
            Destroy(trans.gameObject);
        }

        for (int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].RemovedFromList)
            {
                continue;
            }
            Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
        }
    }

    //Updating the player list when new players arrive
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerList();
        /*Instantiate(PlayerListItemPrefab, PlayerListContent).GetComponent<PlayerListItem>().SetUp(newPlayer);*/
    }

    //Also updating the player list when players leave
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayerList();
    }

    //When the player leaves their playeritem will be destroyed
    void UpdatePlayerList()
    {
        foreach (PlayerItem item in playerItemsList)
        {
            Destroy(item.gameObject);
        }
        playerItemsList.Clear();

        if (PhotonNetwork.CurrentRoom == null)
        {
            return;
        }

        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            PlayerItem newPlayerItem = Instantiate(playerItemPrefab, playerItemParent);
            newPlayerItem.SetPlayerInfo(player.Value);

            if (player.Value == PhotonNetwork.LocalPlayer)
            {
                newPlayerItem.ApplyLocalChanges();
            }

            playerItemsList.Add(newPlayerItem);
        }
    }

    //The player can quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
