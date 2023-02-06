using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    //Script by: Jacqueline Hernandez

    //Creating a bool for if our game is paused
    public static bool GameIsPaused = false;

    //Reference to the pauseMenu UI
    public GameObject pauseMenuUI;
    //Initializing audio sources
    /*[SerializeField] private AudioSource pauseSoundEffect;
    [SerializeField] private AudioSource clickSoundEffect;*/


    //When the P key is pressed our PauseMenu is set active
    //If GameIsPaused is false it will call the Resume method
    //Else we call our Pause method
    //We also play the sound effects when the buttons are clicked
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
                /*pauseSoundEffect.Play();*/
            }
            else
            {
                Pause();
                /*pauseSoundEffect.Play();*/
            }
        }
    }

    //When we resume our game our PauseMenu is false which means it is inactive or not displayed
    //Our timescale resumes
    //And our GameIsPaused is false because our game is not paused
    //We play the pause sound effect
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        /*pauseSoundEffect.Play();*/

    }

    //The pause Method is used to display the PauseMenu UI
    //When we pause our game everything freezes except for the music
    //Also in unity we set the pause menu with a little animation which slowly darkens the screen
    //When we pause GameIsPaused is true
    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    //Play the sound effect when controls button is pressed
    /* public void Controls()
     {
         clickSoundEffect.Play();
     }

     //Play the sound effect when back button is pressed
     public void Back()
     {
         clickSoundEffect.Play();
     }*/

    //Play the sound effect when back button is pressed
    //Quit the application if you get mad at the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
