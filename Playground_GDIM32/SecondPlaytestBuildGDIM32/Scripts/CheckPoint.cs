using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    //Script by Jacqueline Hernandez

    //Here we are assigning the value for our progress bar each time the player reaches a checkpoint
    //Also serializing a audio source that will play each time we reach a checkpoint
    public int progressValue = 25;
    [SerializeField] private AudioSource checkpointSoundEffect;

    //Everytime the player triggers a checkpoint the score will increase by 25%
    //We disable the collider because we do not want the player to keep on spamming the progress bar
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            checkpointSoundEffect.Play();
            ProgressBarManager.Instance.ChangeProgress(progressValue);
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
