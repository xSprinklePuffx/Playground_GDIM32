using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactEffect : MonoBehaviour
{
    //Script by Jacqueline Hernandez

    //Reference to the animator of impactEffect
    private Animator anim;

    //We get the component and set the name
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    //We destroy the impactEffect upon impact to the enemy
    void Update()
    {
        Destroy(gameObject, 0.25f);
    }
}
