using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    // Script by: Markesha Big

    // Current state of the enemy;

    public EnemyState currentEnemyState;

    public LayerMask detectionLayer;
    public float radius;

    private void Awake()
    {

    }

    void Update()
    {

        // Call upon state machine to be used so that the different states are recognized.

        StateMachine();
        
    }

    // This is used to determine if the enemy is close enough to attack the enemy.
    // Using colliders to determine if the enemy is close enough.

    // This is our state machine that looks at the enemies state.

    private void StateMachine()
    {

        // The next state will be the current state that the enemy will be.
        // The question mark is used to see if the current state of the enemy is null.

        EnemyState nextEnemyState = currentEnemyState?.RunEnemyCurrentState();

        if (nextEnemyState != null)
        {
            // Have the enemy switch to the next state.
            SwitchTheState(nextEnemyState);
        }
        
    }

    // This is called to switch the enemy states to the next one.

    private void SwitchTheState(EnemyState nextState)
    {
        currentEnemyState = nextState;
    }
}
