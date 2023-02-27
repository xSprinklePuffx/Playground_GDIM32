using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System;

public class PlayerController : MonoBehaviour
{
    //Script by: Jacqueline Hernandez

    // Edited by: Markesha Big
    // Placing code in when player is hurt by enemy.

    // Number of lives the player has before death.

    public int playerLives;

    //Initializng rigidbody of our player
    //Calling reference to the animator component
    //Creating a bool for when our player is facing right (this will help make sure our player turns the right way depending on which direction they are going)
    private Rigidbody2D rb2D;
    public Animator animator;
    private bool facingRight = true;

    //Setting floats for jumpSpeed and moveSpeed for our character as well as one for horizontaal movement
    public float jumpSpeed;
    public float moveSpeed;
    public float moveHorizontal;

    //Here I am doing ground checks to check when our player is touching the ground
    //Doing this makes sure that the player could only jump when they touch the ground
    //Without this the player would be able to spam the jump button all the way up

    public Transform platformCheck;
    public float platformCheckRadius;
    public LayerMask platformLayerMask;
    private bool isGrounded;
    //

    PhotonView view;

    //Initializing audio source
    [SerializeField] private AudioSource jumpSoundEffect;

    //Settinbg the values for move and jump speed as well as creating a reference of our rigidbody
    void Start()
    {
        rb2D = gameObject.transform.GetComponent<Rigidbody2D>();

        moveSpeed = 5f;
        jumpSpeed = 118f;

        view = GetComponent<PhotonView>();

    }

    //Here we are checking if our player s touching the ground
    //If they are they will be able to jump
    //Furthermore, the animator.SetBool function is called everytime the player jump is true to activate the jump animation
    void Update()
    {
        if (view.IsMine)
        {
            isGrounded = Physics2D.OverlapCircle(platformCheck.position, platformCheckRadius, platformLayerMask);

            moveHorizontal = Input.GetAxisRaw("Horizontal");

            animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));

            if (Input.GetButtonDown("Jump") && isGrounded && rb2D.velocity.y == 0)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
                jumpSoundEffect.Play();
            }

            if (rb2D.velocity.y == 0)
            {
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsFalling", false);
            }

            if (rb2D.velocity.y > 0)
            {
                animator.SetBool("IsJumping", true);
            }

            if (rb2D.velocity.y < 0)
            {
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsFalling", true);
            }
        }
    }

    //Here we are setting the move speed for the player dependng on which direction they are moving (horizontally)
    //When moveHorizontal > 0 that means the player is moving in the negative direction which means they are moving
    //In the left direction and therefore we would use !facingRight to flip our player in the right direction.
    void FixedUpdate()
    {
        if (view.IsMine)
        {
            if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
            {
                rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
            }
        }


        if (moveHorizontal > 0 && !facingRight)
        {
            Flip();
        }
        if (moveHorizontal < 0 && facingRight)
        {
            Flip();
        }

    }

    // Here we are creating a method Flip() to flip the player accordingly
    void Flip()
    {

        transform.Rotate(0f, 180f, 0f);

        facingRight = !facingRight;
    }

    // When the enemy does damage to the player, this will reduce the lives
    // or amount of hits that player can endure.

    public void PlayerDamaged(int livesReduced)
    {
        // Reducing the player lives by one everytime the enemy hits them.

        playerLives--;

        // If the player has been hit to the point where they are at 0 lives then
        // the player game object is destroyed.

        if (playerLives <= 0)
        {
            // Ensuring to destroy the player.

            Destroy(this.gameObject);

        }
    }

}
