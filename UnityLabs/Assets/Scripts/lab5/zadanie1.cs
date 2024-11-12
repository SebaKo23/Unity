using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatform : MonoBehaviour
{
    public float platformSpeed = 2f;
    public Transform targetPoint;
    private bool isMoving = false;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 currentTarget;

    private void Start()
    {
        startPosition = transform.parent.position;
        endPosition = targetPoint.position; 
        currentTarget = endPosition;
    }

    private void Update()
    {
        if (isMoving)
        {
            if (Vector3.Distance(transform.parent.position, currentTarget) < 0.02f)
            {
                currentTarget = (currentTarget == endPosition) ? startPosition : endPosition;
                return;
            }
            transform.parent.position = Vector3.MoveTowards(transform.parent.position, currentTarget, platformSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.parent = transform.parent;

            isMoving = true;
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
