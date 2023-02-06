using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverElevator : MonoBehaviour
{
    //Script by: Samantha Zavaleta Gonzalez

    // Here we are serializing components and setting variables for our elevator
    // Accessing the LeverSwitch script so that we only accept objects that have that script attatched to them
    // MovetoPoint and nextPoint are the points which our elevator will follow
    //Setting the elevator speed to public so we can edit it in Unity
    [SerializeField] LeverSwitch Triggeractivation;
    [SerializeField] Transform moveToPoint;
    [SerializeField] Transform nextPoint;
    [SerializeField] float speed;

    //If the trigger is activated TriggerActivated is set to true and our elevator can move
    //If the trigger is not active TriggerActivated is set to false and our elevator will not move
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
