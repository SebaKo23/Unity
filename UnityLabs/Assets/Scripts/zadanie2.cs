using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float speed = 2f;
    private float startPosX;
    private bool moveRight = true;

    void Start()
    {
        startPosX = transform.position.x;
    }

    void Update()
    {
        if (moveRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (transform.position.x >= startPosX + 10f)
                moveRight = false;
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x <= startPosX)
                moveRight = true;
        }
    }
}
