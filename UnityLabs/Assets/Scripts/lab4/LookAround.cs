using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public Transform player;

    public float sensitivity = 200f;

    public float YRot = 0f;    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        player.Rotate(Vector3.up * mouseXMove);

        YRot -= mouseYMove;
        YRot = Mathf.Clamp(YRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(YRot, 0f, 0f);

    }
}