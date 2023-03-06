using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowBehaviour : StateMachineBehaviour
{
    //Script by Jacqueline Hernandez

    //Here we are assigning the speed at which our enemy should move
    //Serializing a sound effect for when our enemy starts the follow
    //We are also creating a transform for the position of our player
    private Transform playerPosition;
    public float speed;
    [SerializeField] private AudioSource followSoundEffect;

    //Here we are getting that audio source component from our enemy
    //We are also playing it right when the enemy starts the follow
    //We will find the player to chase after via the tag "Player"
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        followSoundEffect = animator.GetComponent<AudioSource>();
        followSoundEffect.Play();
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    //If the player has pressed the space key isFollowing is false so the player stops their chase
    //However if they press P then the enemy begins it's patrol
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, playerPosition.position, speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isFollowing", false);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            animator.SetBool("isPatrolling", true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
