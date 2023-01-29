using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Miniature")]

public class Miniature : PowerupEffect
{
    public float multiplier;
    public float velocity;

    public override void Apply(GameObject target)
    {
        target.transform.localScale /= multiplier;
        target.GetComponent<PlayerController>().jumpSpeed *= velocity;
        target.GetComponent<SpriteRenderer>().color = Color.blue;
    }

    public override void Revert(GameObject target)
    {
        target.transform.localScale *= multiplier;
        target.GetComponent<PlayerController>().jumpSpeed /= velocity;
        target.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
