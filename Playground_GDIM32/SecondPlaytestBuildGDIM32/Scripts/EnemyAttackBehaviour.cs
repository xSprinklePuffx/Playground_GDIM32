using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBehaviour : StateMachineBehaviour
{

    // Script by: Markesha Big

    // This is the enemy attack behaviour associated with the animator.

    // Creating a player transformer that will locate the player's position.

    private Transform player;

    // How fast our enemy will be attacking the player.

    public float attackSpeed;

    // Distance where the enemy can't follow the player anymore. Should be the same.

    public float followDistance;

    // Distance where the enemy can attack the player. Should be the same.

    public float attackDistance;

    // When the enemy first enters the attack state.

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        // Setting the player's location to the tag on Unity.

        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // When the enemy is attacking.

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        // Calculating the vector between the enemy and player.

        Vector2 distance = player.position - animator.transform.position;

        // If the distance between the player and enemy are within the follow distance then the following
        // bool remains true.

        // If the enemy is within attack range then they will attack, but if not then they remain chasing.

        if (distance.magnitude < followDistance)
        {
            animator.SetBool("isFolllowing", true);

            if (distance.magnitude > attackDistance)
            {
                animator.SetBool("inRange", false);
            }

            else if (distance.magnitude < attackDistance)
            {
                animator.SetBool("inRange", true);
            }
        }

        // If the distnace between the enemy and player is above the follow distance, then the enemy
        // remains in idle state until prompted.

        else if (distance.magnitude > followDistance)
        {
            animator.SetBool("isFollowing", false);
        }

    }

    // When the enemy stops attacks.

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
