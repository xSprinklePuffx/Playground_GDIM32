using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    //Script by: Jacqueline Hernandez

    //We will be accessing the TriggerPlatformMovement script for platform
    TriggerPlatformMovement platform;

    //Getting that movement component from our platform
    void Start()
    {
        platform = GetComponent<TriggerPlatformMovement>();
    }

    //In our TriggerPlatformMovement we created a bool called canMove, well if our player triggers that platform canMove is set to true
    private void OnTriggerEnter2D(Collider2D collider)
    {
        platform.canMove = true;
    }
}