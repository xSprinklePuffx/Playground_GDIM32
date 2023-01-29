using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/SpeedBuff")]

public class SpeedBuff : PowerupEffect
{
    public float speed;

    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerController>().moveSpeed += speed;
        target.GetComponent<SpriteRenderer>().color = Color.green;
    }

    public override void Revert(GameObject target)
    {
        target.GetComponent<PlayerController>().moveSpeed -= speed;
        target.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
