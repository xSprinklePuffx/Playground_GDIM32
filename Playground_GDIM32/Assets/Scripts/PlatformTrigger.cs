using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    TriggerPlatformMovement platform;

    void Start()
    {
        platform = GetComponent<TriggerPlatformMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        platform.canMove = true;
    }
}
