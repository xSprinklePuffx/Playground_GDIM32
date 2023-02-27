using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //Script by Jacqueline Hernandez

    //This script will be attatched to our mysterybox gameObject
    //We set the increment value of our coin
    public int coinValue = 1;

    //If the gameObject has been collided by the player the coinValue will change
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.Instance.ChangeScore(coinValue);
        }
    }
}