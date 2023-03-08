using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsTrigger : MonoBehaviour
{
    //Script by Jacqueline Hernandez

    //Serializing our audio source to make it visible in the inspector
    //Setting the coin value
    [SerializeField] private AudioSource coinSoundEffect;
    public int coinValue = 1;

    //This script is different than the coin script because this one uses trigger coins to gain a coin
    //When the player triggers the coin their score will increase and they will gain a coin
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            coinSoundEffect.Play();
            ScoreManager.Instance.ChangeScore(coinValue);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
