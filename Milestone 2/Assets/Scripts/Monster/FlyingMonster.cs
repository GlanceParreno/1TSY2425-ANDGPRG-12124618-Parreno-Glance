using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMonster : Monster
{
    public Transform[] waypoints; // Array of waypoint transforms
    private int currentWaypoint = 0;

    private void Update()
    {
        Move();
    }

    public override void Move()
    {
        if (currentWaypoint < waypoints.Length)
        {
            Vector3 target = waypoints[currentWaypoint].position;
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            // Check if reached current waypoint
            if (Vector3.Distance(transform.position, target) < 0.1f)
            {
                currentWaypoint++;
            }
        }
    }
}

