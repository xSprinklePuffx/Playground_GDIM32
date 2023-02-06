using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlatformMovement : MonoBehaviour
{
    //Setting a bool for when our platform can move
    public bool canMove;

    //Setting the speeds startpoint and waypoints visible in the inspector
    [SerializeField] float speed;
    [SerializeField] int startPoint;
    [SerializeField] Transform[] waypoints;

    int i;
    bool reverse;

    //Our platform will start where our first waypoint is located
    void Start()
    {
        transform.position = waypoints[startPoint].position;
        i = startPoint;
    }

    //Here we will be checking to see where our platform is, if it is at startpoint it will go down (reverse = false) but if our platform is at a greater distance than that it will reverse
    //Of course we can only see the effects of this when our platform is moving
    //Once canMove is true then our platform could start moving to the waypoints
    void Update()
    {
        if (Vector2.Distance(transform.position, waypoints[i].position) < 0.01f)
        {
            canMove= false;

            if (i == waypoints.Length -1)
            {
                reverse=true;
                i--;
                return;
            }
            else if (i == 0)
            {
                reverse = false;
                i++;
                return;
            }

            if (reverse)
            {
                i--;
            }
            else
            {
                i++;
            }
        }

        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[i].position, speed * Time.deltaTime);
        }
    }
}
