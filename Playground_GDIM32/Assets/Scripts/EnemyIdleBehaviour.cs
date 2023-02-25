using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleBehaviour : StateMachineBehaviour
{
    //Script by: Markesha Big

    // This is controlling the idle's behaviour.

    private Transform player;

    // Minimum distance between the enemy and player before chasing.

    public float followDistance;

    // The enemy's start function when idle.

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        // Locating the player's position.

        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // As long as the enemy is idle, this will continue to update per scene.

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        // Check if the player is within a range to be able to make the following bool true.

        // Calculating the vector between the enemy and player.

        Vector2 distance = player.position - animator.transform.position;

        // Using the magnitude so that it can be compared to the minimum distance.

        if (distance.magnitude < followDistance)
        {
            animator.SetBool("isFollowing", true);
        }
        else
        {
            animator.SetBool("isFollowing", false);
        }
        
    }

    // When the enemy leaves the idle state.

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
