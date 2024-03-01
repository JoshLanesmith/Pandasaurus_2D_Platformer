using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] public float speed;

    private ItemCollector itemCollector;
    private bool followAnyways = false;

    private void Start()
    {
        itemCollector = GetComponent<ItemCollector>();
        if (!CompareTag("Blue") && !CompareTag("Orange") && !CompareTag("Purple") && !CompareTag("Magic"))
        {
            followAnyways = true;
        }
    }


    private void Update()
    {
        if (followAnyways  || !itemCollector.isBeingCaptured)
        {   
            if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        }
    }
}
