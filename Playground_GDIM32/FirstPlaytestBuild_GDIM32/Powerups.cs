using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    //Script by: Jacqueline Hernandez

    //Serializing the active time given to each powerup
    //Accessing a powerup effect with a PowerupEffect script attatched to it
    [SerializeField] PowerupEffect powerupEffect;
    [SerializeField] float activeTime = 4f;

    //When our player collides with this effect we can start the coroutine
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Pickup(collision));
    }

    //Our effect will apply to the player
    //However the gameObject will become invisible
    //We do not destroy the game Object because that would mean that the effect would not get a chance to work
    //After the activeTime is finished we will revert the conditions (powerup effect) given to our player
    IEnumerator Pickup(Collision2D collision)
    {
        powerupEffect.Apply(collision.gameObject);

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(activeTime);

        powerupEffect.Revert(collision.gameObject);
    }
}
