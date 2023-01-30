using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Powerups/Coins")]

public class ItemCollector : PowerupEffect
{
    public override void Apply(GameObject target)
    {
        target.GetComponent<ScoreManager>().IncrementScore(1);
        target.GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    public override void Revert(GameObject target)
    {
        target.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
