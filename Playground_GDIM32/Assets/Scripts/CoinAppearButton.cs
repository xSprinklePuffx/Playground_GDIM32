using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAppearButton : MonoBehaviour
{
    //Script by Jacqueline Hernandez

    //Creating a list of GameObjects which we want to appear when the button is pressed in the game
    //Acessing the button's animator component
    public List<GameObject> appearables;

    private Animator anim;

    //Setting the animator component
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    //When the button is triggered the coroutine Appear will begin
    private void OnTriggerEnter2D(Collider2D collider)
    {
        anim.SetBool("On", true);
        StartCoroutine(Appear());
    }

    //Here we are setting each GameObject in appearables to true
    //Then wait for 20 seconds
    //Then destroy all the GameObjects in appearables
    //Also set the bool "On" to false to show the player that the button is no longer active
    IEnumerator Appear()
    {
        foreach (GameObject obj in appearables)
        {
            obj.SetActive(true);
        }

        yield return new WaitForSeconds(20);

        foreach (GameObject obj in appearables)
        {
            Destroy(obj);
        }
        anim.SetBool("On", false);
    }
}
