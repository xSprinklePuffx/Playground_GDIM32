using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    //Script by Jacqueline Hernandez

    //Making our audio source visbible in the inspector
    [SerializeField] private AudioSource music;

    //When we start the game the music will be stopped so it will not be playing
    void Start()
    {
        music.Stop();
    }

    //When the player triggers the music trigger the music will play
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            music.Play();
        }
    }

    //When the player leaves the trigger the music stops playing
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            music.Stop();
        }
    }
}
