using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    //Script by: Jacqueline Hernandez

    //Instance of the MenuManager meaning that we can access the menus here without the need for instantiating it again
    public static MenuManager Instance;

    //List of menus
    [SerializeField] Menu[] menus;

    private void Awake()
    {
        Instance = this;
    }

    //The menuName that we have set in our Menu script will be taken into consideration here for what menu we should be opening up
    public void OpenMenu(string menuName)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].menuName == menuName)
            {
                menus[i].Open();
            }
            else if (menus[i].open)
            {
                CloseMenu(menus[i]);
            }
        }
    }

    //This OpenMenu() is different from the other because rather than a string we are calling here a gameObject with the script 'Menu' attatched to it
    public void OpenMenu(Menu menu)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].open)
            {
                CloseMenu(menus[i]);
            }
        }
        menu.Open();
    }

    //Here we will close that menu
    public void CloseMenu(Menu menu)
    {
        menu.Close();
    }

    //For when our player wants to quit
    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    //For when our player enters the game
    public void EnterGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
