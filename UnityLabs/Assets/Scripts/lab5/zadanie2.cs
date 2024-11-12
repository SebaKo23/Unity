using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public float doorSpeed = 2.0f;  
    public GameObject door;        
    public float closedPosition = -34.0f;    
    public float openPosition = -31.0f;   
    private bool doorOpen = false;  


    private void Update()
    {
        if(doorOpen)
        {
            if(door.transform.position.z < openPosition)
            {
                door.transform.Translate(0f, 0f, doorSpeed * Time.deltaTime);
            }
        }
        else
        {
         if(door.transform.position.z > closedPosition)
            {
                door.transform.Translate(0f, 0f, -doorSpeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorOpen = false;
        }
    }

}
