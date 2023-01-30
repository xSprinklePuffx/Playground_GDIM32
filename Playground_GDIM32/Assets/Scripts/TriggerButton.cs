using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerButton : MonoBehaviour
{
    public bool TriggerActivated;

    public TriggerButton Triggeractivation;

    private Animator anim;

    void Start()
    {
        TriggerActivated = false;
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        anim.SetBool("On", true);
        TriggerActivated = true;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        anim.SetBool("On", false);
        TriggerActivated = false;
    }
}
