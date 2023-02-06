using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/MegaJump")]

public class MegaJump : PowerupEffect
{
    //Here we are setting up float components for our powerup effect
    [SerializeField] float amount;

    //Upon our player colliding with this powerup effect (player = target), we access the PlayerController script to increase the player's jump speed
    // and the sprite will have a red hue to it
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerController>().jumpSpeed *= amount;
        target.GetComponent<SpriteRenderer>().color = Color.red;
    }

    //After some time all the aforementioned effects will revert back to normal
    public override void Revert(GameObject target)
    {
        target.GetComponent<PlayerController>().jumpSpeed /= amount;
        target.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
