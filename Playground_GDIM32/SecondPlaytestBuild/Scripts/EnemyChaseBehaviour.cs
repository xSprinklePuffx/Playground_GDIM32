using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseBehaviour : StateMachineBehaviour
{

    // Script by: Markesha Big

    // This is the enemy chase behaviour script that will update when player
    // is within range.

    // Creating a player transformer that will locate the player's position.

    private Transform player;

    // How fast our enemy will be chasing the player.

    public float speed;

    // Distance where the enemy can't follow the player anymore.

    public float followDistance;

    // Distance where the enemy can attack the player.

    public float attackDistance;

    // The start function when the enemy is about to chase the player.

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        // Setting the player's location to the tag on Unity.

        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // When the enemy is chasing the player.

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        // Updating the animator so that the enemy is moving toward the player.

        // The vector is player position from the enemy's position.

        Vector2 playerPos = Vector2.MoveTowards(animator.transform.position, player.position, speed * Time.deltaTime);


        // Calculating the vector between the enemy and player.

        Vector2 distance = player.position - animator.transform.position;

        // Ensuring that the enemy can follow the player within the distance or not.

        // If the player is no longer within attack range, then make isFollowing false.

        // This needs to be the same with the other set minimum distance.

        if (distance.magnitude > followDistance)
        {
            animator.SetBool("isFollowing", false);
        }

        else if (distance.magnitude < followDistance)
        {
            animator.SetBool("isFollowing", true);
            animator.transform.position = playerPos;
        }

        if (distance.magnitude > attackDistance)
        {
            animator.SetBool("inRange", false);
        }

        else if (distance.magnitude < attackDistance)
        {
            animator.SetBool("inRange", true);
        }

    }

    // When the enemy is no longer chasing the player.

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    
}
