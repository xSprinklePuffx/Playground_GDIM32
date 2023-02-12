using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    //Script by: Jacqueline Hernandez

    //Serializing the input field which is where our player will input their username
    //Serializing the button text that will say connecting when the player presses the connect button
    [SerializeField] TMP_InputField usernameInput;
    [SerializeField] TMP_Text buttonText;
    
    //Here we will only start connecting if the player has input at least one or more characters for their username
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

    //Upon connection the player will connect to the lobby
    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("Lobby");
    }
}
