using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    //Script by: Markesha Cody Big

    //Serializing our audio for the completion sound effect
    [SerializeField] private AudioSource completeSoundEffect;
    private Animator anim;

    //Setting our animator component
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    //When our player triggers the door to the next level the completeSoundEffect will play and animator will also play
    private void OnTriggerEnter2D(Collider2D collider)
    {
        anim.SetBool("Opened", true);
        completeSoundEffect.Play();
        Invoke("CompleteLevel", 2f);
    }

    //We will switch to the next scene
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
