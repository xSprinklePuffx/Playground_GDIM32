using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/SpeedBuff")]

public class SpeedBuff : PowerupEffect
{
    //Script by: Jacqueline Hernandez

    //Here we are setting up float components for our powerup effect
    [SerializeField] float speed;

    //Upon our player colliding with this powerup effect (player = target), we access the PlayerController script to increase the player's move speed
    // and the sprite will have a green hue to it
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerController>().moveSpeed += speed;
        target.GetComponent<SpriteRenderer>().color = Color.green;
    }

    //After some time all the aforementioned effects will revert back to normal
    public override void Revert(GameObject target)
    {
        target.GetComponent<PlayerController>().moveSpeed -= speed;
        target.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
