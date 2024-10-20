using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject cubePrefab;
    public int numberOfCubes = 10;
    public Vector2 planeSize = new Vector2(10, 10);

    void Start()
    {
        SpawnCubes();
    }

    void SpawnCubes()
    {
        HashSet<Vector3> occupiedPositions = new HashSet<Vector3>();

        for (int i = 0; i < numberOfCubes; i++)
        {
            Vector3 randomPosition;

            do
            {
                float xPos = Random.Range(-planeSize.x / 2, planeSize.x / 2);
                float zPos = Random.Range(-planeSize.y / 2, planeSize.y / 2);
                randomPosition = new Vector3(xPos, 0.5f, zPos);
            } while (occupiedPositions.Contains(randomPosition));

            occupiedPositions.Add(randomPosition);
            Instantiate(cubePrefab, randomPosition, Quaternion.identity);
        }
    }
}
