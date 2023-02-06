using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Miniature")]

public class Miniature : PowerupEffect
{
    //Here we are setting up float components for our powerup effect
    [SerializeField] float multiplier;
    [SerializeField] float velocity;

    //Upon our player colliding with this powerup effect (player = target), their localScale will decrease (making them smaller), they will jump higher
    // and the sprite will have a blue hue to it
    public override void Apply(GameObject target)
    {
        target.transform.localScale /= multiplier;
        target.GetComponent<PlayerController>().jumpSpeed *= velocity;
        target.GetComponent<SpriteRenderer>().color = Color.blue;
    }

    //After some time all the aforementioned effects will revert back to normal
    public override void Revert(GameObject target)
    {
        target.transform.localScale *= multiplier;
        target.GetComponent<PlayerController>().jumpSpeed /= velocity;
        target.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
