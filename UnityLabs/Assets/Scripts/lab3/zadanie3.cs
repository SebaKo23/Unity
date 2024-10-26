using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMovement : MonoBehaviour
{
    public float speed = 2f;
    private Vector3 startPosition;
    private int currentStep = 0;
    private float distanceMoved = 0f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (distanceMoved < 10f)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            distanceMoved += speed * Time.deltaTime;
        }
        else
        {
            transform.Rotate(0, 90f, 0);
            currentStep++;
            distanceMoved = 0f;
        }

        if (currentStep >= 4)
        {
            currentStep = 0;
            transform.position = startPosition;
        }
    }
}
