using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverElevator : MonoBehaviour
{
    public LeverSwitch Triggeractivation;
    public Transform moveToPoint;
    public Transform nextPoint;
    public float speed;

    void Update()
    {
        float step = speed * Time.deltaTime;

        if (Triggeractivation.TriggerActive == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveToPoint.position, step);
        }
        else if (Triggeractivation.TriggerActive == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, nextPoint.position, step);
        }
    }
}
