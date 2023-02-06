using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    //Script by: Jacqueline Hernandez

    //This script is attatched to all platforms that require movement with the player
    //If our player land on a moving platform they will become a child of that game object which means they will follow the game object wherever it goes
    //Without this the platform would keep on moving and leave the player behind
    //With this script the player will stay stuck on the platform
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    //Once the player hops off the platform it is no longer a child of the platform
    //The player retruns as its own object in the hierarchy
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
