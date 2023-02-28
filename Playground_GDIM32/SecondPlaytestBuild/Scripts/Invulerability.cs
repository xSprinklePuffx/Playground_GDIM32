using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Invulnerable")]

public class Invulerability : PowerupEffect
{
    //Script by: Jacqueline Hernandez

    //Here we are setting up float components for our powerup effect
    [SerializeField] float speed;
    [SerializeField] float multiplier;
    [SerializeField] float amount;

    //Upon our player colliding with this powerup effect (player = target), their localScale will be increased, their jumps will be higher, their speed will be faster,
    // and the sprite will have a grey hue to it
    public override void Apply(GameObject target)
    {
        target.transform.localScale *= multiplier;
        target.GetComponent<PlayerController>().jumpSpeed *= amount;
        target.GetComponent<PlayerController>().moveSpeed += speed;
        target.GetComponent<SpriteRenderer>().color = Color.grey;
    }

    //After some time all the aforementioned effects will revert back to normal
    public override void Revert(GameObject target)
    {
        target.transform.localScale /= multiplier;
        target.GetComponent<PlayerController>().jumpSpeed /= amount;
        target.GetComponent<PlayerController>().moveSpeed -= speed;
        target.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
