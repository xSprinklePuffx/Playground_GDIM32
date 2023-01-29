using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ConnectToServer : MonoBehaviour
{
    [SerializeField] TMP_InputField usernameInput;
    [SerializeField] TMP_Text buttonText;

    public void onClickConnect()
    {
        if (usernameInput.text.Length >= 1)
        {
            buttonText.text = "Connecting...";
            Connect();
        }
    }

    public void Connect()
    {
        SceneManager.LoadScene("Lobby");
    }
}
