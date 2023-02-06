using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    //Script by: Jacqueline Hernandez

    //Here I am creating a serialize list of waypoints so that I can drag and drop waypoints in Unity
    //I set the waypoint index to 0
    //I adjust the speed at which the onjects should move between waypoints (serialized so that we can edit the speed in Unity as well)
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed = 2f;

    private int currentWaypointIndex = 0;

    //Update is used to move the object from one waypoint to another, it will go back and forth between the two points
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex= 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
