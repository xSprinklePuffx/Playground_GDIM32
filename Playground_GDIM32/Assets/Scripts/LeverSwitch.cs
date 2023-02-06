using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSwitch : MonoBehaviour
{
    //Accessing an audio that will play when our switch is pressed
    //Bool for when the trigger is active
    //Serializing our Triggeractivation which will have to be an object that has the LeverSwitch script attatched to it
    [SerializeField] private AudioSource leverSoundEffect;
    public bool TriggerActive;
    [SerializeField] LeverSwitch Triggeractivation;

    //Accessing our animator
    private Animator anim;

    //On start the TriggerActive is set to false because it has not been activated
    void Start()
    {
        TriggerActive = false;
        anim = GetComponent<Animator>();
    }

    //When we collide with the switch our sound effect will play and we will start a coroutine
    private void OnTriggerEnter2D(Collider2D collider)
    {
        leverSoundEffect.Play();
        StartCoroutine(Reset());
    }

    //We set the animator to true and wait for 3 seconds for the animator to be false once again
    //Trigger active will be set to true when the player has collided with the switch, then it will wait 3 seconds before setting back to false
    IEnumerator Reset()
    {
        anim.SetBool("On", true);
        TriggerActive = true;

        yield return new WaitForSeconds(3);

        anim.SetBool("On", false);
        TriggerActive = false;
    }
}
