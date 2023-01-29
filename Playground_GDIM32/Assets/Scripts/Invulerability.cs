using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Invulnerable")]

public class Invulerability : PowerupEffect
{
    public float speed;
    public float multiplier;
    public float amount;

    public override void Apply(GameObject target)
    {
        target.transform.localScale *= multiplier;
        target.GetComponent<PlayerController>().jumpSpeed *= amount;
        target.GetComponent<PlayerController>().moveSpeed += speed;
        target.GetComponent<SpriteRenderer>().color = Color.grey;
    }

    public override void Revert(GameObject target)
    {
        target.transform.localScale /= multiplier;
        target.GetComponent<PlayerController>().jumpSpeed /= amount;
        target.GetComponent<PlayerController>().moveSpeed -= speed;
        target.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
