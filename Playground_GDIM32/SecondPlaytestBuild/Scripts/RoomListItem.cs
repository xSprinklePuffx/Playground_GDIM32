using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;


public class RoomListItem : MonoBehaviour
{
    //Script by Jacqueline Hernandez

    //Setting the text that will display the name of our room visible in the inspector
    [SerializeField] TMP_Text text;

    public RoomInfo info;

    //We are retrieving the name of the room and displaying it in the text box
    public void SetUp(RoomInfo _info)
    {
        info = _info;
        text.text = _info.Name;
    }

    //When the player clicks to join they will be in the same room as the other player(s)
    public void OnClick()
    {
        Launcher.Instance.JoinRoom(info);
    }
}
