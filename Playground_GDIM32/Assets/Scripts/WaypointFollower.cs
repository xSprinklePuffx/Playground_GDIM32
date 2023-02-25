using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    //Script by: Jacqueline Hernandez

    // Edited by: Markesha Big
    // Placing in wait times for the enemy since this is the enemy patrol behviour.

    //Here I am creating a serialize list of waypoints so that I can drag and drop waypoints in Unity
    //I set the waypoint index to 0
    //I adjust the speed at which the onjects should move between waypoints (serialized so that we can edit the speed in Unity as well)
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed = 2f;

    // Enemy wait time when reached the waypoint.

    private float enemyWaitTime;

    public float enemyStartWaitTime;

    private int currentWaypointIndex = 0;

    // Placing an animator to changle the enemy animation.

    public Animator enemyAnimator;

    // Start by assigning the wait time to the start wait time.

    private void Start()
    {
        enemyWaitTime = enemyStartWaitTime;
    }

    //Update is used to move the object from one waypoint to another, it will go back and forth between the two points
    private void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);

        // Flipping the enemy based the x cordination of the enemy position from index.

        if (waypoints[currentWaypointIndex].transform.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }

        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }


        if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < .1f)
        {

            // If the wait time is 0, then move the enemy to the next index.
            // There is no wait time needed when reached the waypoint.

            if (enemyWaitTime <= 0)
            {
                currentWaypointIndex++;
                enemyWaitTime = enemyStartWaitTime;

                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;
                }

                enemyAnimator.SetBool("isIdle", false);

            }

            // Subtracting from the in game time so that the enemy remains idle.

            else
            {
                enemyWaitTime -= Time.deltaTime;

                enemyAnimator.SetBool("isIdle", true);

            }

        }

    }
}
