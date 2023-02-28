using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    //Script by Jacqueline Hernandez

    //Serializing an input field for the player's username
    //Also serializing the text for our button
    [SerializeField] TMP_InputField usernameInput;
    [SerializeField] TMP_Text buttonText;

    //Before the player can connect to the game, they have to type at least one character into the namespace
    //Once that's done the button text will go from "connect" to "connecting"
    //The user will connect using the photon network settings
    public void onClickConnect()
    {
        if (usernameInput.text.Length >= 1)
        {
            PhotonNetwork.NickName = usernameInput.text;
            buttonText.text = "Connecting...";
            Debug.Log("Connecting To Master");
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    //They will join the scene called "Lobby" once they have connected to the game server
    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("Lobby");
    }
}
