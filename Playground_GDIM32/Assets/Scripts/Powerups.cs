using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public PowerupEffect powerupEffect;
    public float activeTime = 4f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Pickup(collision));
    }

    IEnumerator Pickup(Collision2D collision)
    {
        powerupEffect.Apply(collision.gameObject);

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(activeTime);

        powerupEffect.Revert(collision.gameObject);
    }
}
