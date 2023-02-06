using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Powerups/Coins")]

public class ItemCollector : PowerupEffect
{
    //The ScoreManager script is attatched to our player so we gain access to that to increment the score via the IncrementScore method
    //We also change the SpriteRenderer to yellow for funziez
    public override void Apply(GameObject target)
    {
        target.GetComponent<ScoreManager>().IncrementScore(1);
        target.GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    //Revert the player color back to normal but leave the score incremented
    public override void Revert(GameObject target)
    {
        target.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
