using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerButton : MonoBehaviour
{
    //Bool for when the trigger is active
    //Serializing our Triggeractivation which will have to be an object that has the LeverSwitch script attatched to it
    //Also accessing our animator attatched to the button
    public bool TriggerActivated;

    [SerializeField] TriggerButton Triggeractivation;

    private Animator anim;

    //On start the TriggerActive is set to false because it has not been activated
    //Getting our animator from our gameObject and assigning it to anim
    void Start()
    {
        TriggerActivated = false;
        anim = GetComponent<Animator>();
    }

    //When we collide with the button TiggerActivated is true so our platform can move
    private void OnTriggerEnter2D(Collider2D collider)
    {
        anim.SetBool("On", true);
        TriggerActivated = true;
    }

    //Once we leave the button TriggerActivated is false so our platform will revert back to its original position
    private void OnTriggerExit2D(Collider2D collider)
    {
        anim.SetBool("On", false);
        TriggerActivated = false;
    }
}
