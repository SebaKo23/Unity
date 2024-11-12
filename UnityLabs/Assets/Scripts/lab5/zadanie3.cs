using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiWaypointPlatform : MonoBehaviour
{
    public float platformSpeed = 2f;
    public List<Vector3> waypoints; 
    private int currentWaypointIndex = 0;
    private bool isReversing = false;
    private bool isMoving = false;

    private void Start()
    {
        if (waypoints == null || waypoints.Count < 2)
        {
            Debug.LogError("Please assign at least two waypoints in the Inspector.");
            return;
        }

        transform.parent.position = waypoints[currentWaypointIndex];
    }

    private void Update()
    {
        if (isMoving && waypoints.Count > 1)
        {
            Vector3 targetPosition = waypoints[currentWaypointIndex];
            
            transform.parent.position = Vector3.MoveTowards(transform.parent.position, targetPosition, platformSpeed * Time.deltaTime);
            
            if (Vector3.Distance(transform.parent.position, targetPosition) < 0.02f)
            {
                if (!isReversing)
                {
                    currentWaypointIndex++;
                    if (currentWaypointIndex >= waypoints.Count)
                    {
                        currentWaypointIndex -= 2;
                        isReversing = true;
                    }
                }
                else
                {
                    currentWaypointIndex--;
                    if (currentWaypointIndex < 0)
                    {
                        currentWaypointIndex = 1;
                        isReversing = false;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isMoving = true;
            other.gameObject.transform.parent = transform.parent;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isMoving = false;
            other.gameObject.transform.parent = null;
        }
    }
}
