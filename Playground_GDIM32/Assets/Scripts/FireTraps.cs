using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTraps : MonoBehaviour
{
    //Accessing the animator connected to our firetraps
    private Animator anim;

    //Starting the coroutine Reset() which will be used to create that fire effect that last a couple seconds, goes away, and then comes back again
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(Reset());
    }

    //We set our fire to true and wait for 3 seconds before turning the fire off
    //To make this even more real we adjusted the boxcollider in the animator so that when the fire is on the collider matches the height of the fire
    IEnumerator Reset()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);

            anim.SetBool("On", true);

            yield return new WaitForSeconds(3);

            anim.SetBool("On", false);
        }

    }
}
