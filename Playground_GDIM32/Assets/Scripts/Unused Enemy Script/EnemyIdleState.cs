using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{

    // Script by: Markesha Big

    /* This is the enemy idle state of the enemy which will then implement 
     * from the abstract base class. */

    // Will be used to help transition from idle to chase.

    /* Want to make sure that the player is within the enemy's range to
     * attack the player. */
    public bool playerDetected;

    public override EnemyState RunEnemyCurrentState()
    {
        // If the player is detected, then this will change the enemy state to
        // chase.

        if (playerDetected)
        {
            return this;
        }

        // If player is not detected, then they remain idle.
        else
        {
            return this;
        }
    }
}
