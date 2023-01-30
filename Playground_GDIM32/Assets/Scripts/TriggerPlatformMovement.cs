using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlatformMovement : MonoBehaviour
{
    public bool canMove;

    [SerializeField] float speed;
    [SerializeField] int startPoint;
    [SerializeField] Transform[] waypoints;

    int i;
    bool reverse;

    void Start()
    {
        transform.position = waypoints[startPoint].position;
        i = startPoint;
    }

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
