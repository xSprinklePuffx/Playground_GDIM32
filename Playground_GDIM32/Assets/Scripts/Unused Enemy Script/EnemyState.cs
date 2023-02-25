using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState : MonoBehaviour
{
    // Script by: Markesha Big

    // This is the base class in which the enemy script will call upon this one.
    // Other classes will inherit from this class.

    // Return the state.

    public abstract EnemyState RunEnemyCurrentState();
}
