using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{

    // Script by: Markesha Big

    /* This is the enemy attack state of the enemy which will then implement 
     * from the abstract base class. */

    public override EnemyState RunEnemyCurrentState()
    {
        // Enemy is attacking.
        return this;
    }
}
