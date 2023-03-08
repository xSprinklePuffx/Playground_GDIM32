using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    //Script by Jacqueline Hernandez

    //Assigning variables for the speed of our bullet as well as the damage our bullet will do to the enemy
    //We create a rigidbody for it
    //And we also call a reference to the GameObject prefab we made called impactEffect
    private float speed = 20f;
    private int damage = 50;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public GameObject impactEffect;

    //Adjusting the speed for our bullet
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        Destroy(gameObject, 0.50f);
    }
    //Here is where we detect if our bullet has hit an enemy
    //If it has we instantiate our impact effect GameObject which is an explosion animation that occurs when our bullet hits the enemy
    //We destroy the bullet and enemy on impact
    private void OnTriggerEnter2D(Collider2D hitDetection)
    {
        if(hitDetection.tag == "Enemy")
        {
            GameObject ie = Instantiate(impactEffect) as GameObject;
            ie.transform.position = transform.position;
            Destroy(hitDetection.gameObject);
        }
    }
}
