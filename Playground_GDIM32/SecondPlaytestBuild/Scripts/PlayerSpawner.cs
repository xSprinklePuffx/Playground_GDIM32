using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
    //Script by Jacqueline Hernandez

    //Here we are creating a list of gameObjects which will store all the characters the player can play as
    //Another list for spawnPoints which our player can spawn into
    public GameObject[] playerPrefabs;
    public Transform[] spawnPoints;

    //Here we are assigning a spawnpoint for each player spawned
    //We are spawning the player in which the character they have chosen in the character selection screen
    public void Start()
    {
        int randomNumber = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomNumber];
        GameObject playerToSpawn = playerPrefabs[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
        PhotonNetwork.Instantiate(playerToSpawn.name, spawnPoint.position, Quaternion.identity);
    }
}
