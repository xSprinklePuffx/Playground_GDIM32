using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSwitch : MonoBehaviour
{
    [SerializeField] private AudioSource leverSoundEffect;
    public bool TriggerActive;
    public LeverSwitch Triggeractivation;

    private Animator anim;

    void Start()
    {
        TriggerActive = false;
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        leverSoundEffect.Play();
        StartCoroutine(Reset());
    }

    IEnumerator Reset()
    {
        anim.SetBool("On", true);
        TriggerActive = true;

        yield return new WaitForSeconds(3);

        anim.SetBool("On", false);
        TriggerActive = false;
    }
}
