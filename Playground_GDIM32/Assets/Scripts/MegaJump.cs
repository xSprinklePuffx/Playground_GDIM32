using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/MegaJump")]

public class MegaJump : PowerupEffect
{
    public float amount;

    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerController>().jumpSpeed *= amount;
        target.GetComponent<SpriteRenderer>().color = Color.red;
    }

    public override void Revert(GameObject target)
    {
        target.GetComponent<PlayerController>().jumpSpeed /= amount;
        target.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
