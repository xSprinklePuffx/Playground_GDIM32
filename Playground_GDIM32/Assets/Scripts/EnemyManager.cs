using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    // Script by: Markesha Big

    // This script is to manage the enemy's. They will do damage to the player
    // and can be destroyed by the player as well.

    // Pulling from the player class.

    public int damageToPlayer = 1;

    public PlayerController player;

    // This is when the enemy colliders with the player.

    private void OnTriggerEnter2D(Collider2D target)
    {

        // If the enemy touches the player then the enemy will damage them.


        if (target.CompareTag("Player"))
        {
            // Using the script from PlayerController to register the player is damaged.

            player = target.transform.GetComponent<PlayerController>();

            player.PlayerDamaged(damageToPlayer);

            // Destroying the enemy after contacting player.

            Destroy(this.gameObject);
        }
        
    }

}
