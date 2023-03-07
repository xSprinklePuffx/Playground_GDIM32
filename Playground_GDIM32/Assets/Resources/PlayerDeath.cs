using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    //Script by: Jacqueline Hernandez

    //Players rigidbody
    private Rigidbody2D rb;

    //Death Sound Effect
    [SerializeField] private AudioSource deathSoundEffect;


    //Accessing that component
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //If our player collides with an enemy it will pull up the DeathMenu
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            Death();
        }

        if (collider.gameObject.CompareTag("Saw"))
        {
            Death();
        }
    }

    //The player is unable to move the character
    //The MenuManager will open a gameObject with the script 'Menu' on it where we assign the name called DeathMenu

    public void Death()
    {
        rb.bodyType = RigidbodyType2D.Static;
        deathSoundEffect.Play();
        MenuManager.Instance.OpenMenu("DeadMenu");
    }
}
