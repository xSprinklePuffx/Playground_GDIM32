using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTraps : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(Reset());
    }

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
