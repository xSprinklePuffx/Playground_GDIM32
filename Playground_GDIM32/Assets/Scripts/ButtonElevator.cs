using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonElevator : MonoBehaviour
{
    public TriggerButton Triggeractivation;
    public Transform moveToPoint;
    public Transform nextPoint;
    public float speed;

    void Update()
    {
        float step = speed * Time.deltaTime;

        if (Triggeractivation.TriggerActivated == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveToPoint.position, step);
        }
        else if (Triggeractivation.TriggerActivated == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, nextPoint.position, step);
        }
    }
}
