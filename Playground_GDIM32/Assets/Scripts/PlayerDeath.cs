using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    //Players rigidbody
    private Rigidbody2D rb;

    //Accessing that component
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //If our player collides with an enemy it will start a coroutine Death()
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(Death());
        }
    }

    //The death coroutine will make it so that the player is unable to move the character
    //The MenuManager will open a gameObject with the script 'Menu' on it where we assign the name called RespawnMenu
    //After a couple of seconds we load the scene we were just on

    IEnumerator Death()
    {
        rb.bodyType = RigidbodyType2D.Static;
        MenuManager.Instance.OpenMenu("RespawnMenu");

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
