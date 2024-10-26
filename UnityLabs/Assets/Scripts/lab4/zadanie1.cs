using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomCubesGenerator : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public int numberOfObjects = 10;
    public float delay = 3.0f;
    int objectCounter = 0;
    public GameObject block;
    public Material[] materials;

    void Start()
    {
        Renderer platformRenderer = GetComponent<Renderer>();
        Vector3 rozmiarPlatformy = platformRenderer.bounds.size;
        Vector3 pozycjaPlatformy = transform.position;

        List<int> pozycje_x = new List<int>(Enumerable.Range((int)-rozmiarPlatformy.x / 2, (int)rozmiarPlatformy.x).OrderBy(x => Guid.NewGuid()).Take(numberOfObjects));
        List<int> pozycje_z = new List<int>(Enumerable.Range((int)-rozmiarPlatformy.z / 2, (int)rozmiarPlatformy.z).OrderBy(x => Guid.NewGuid()).Take(numberOfObjects));
        
        for(int i=0; i<numberOfObjects; i++)
        {
            this.positions.Add(new Vector3(pozycjaPlatformy.x + pozycje_x[i], 5, pozycjaPlatformy.z + pozycje_z[i]));
        }
        foreach(Vector3 elem in positions){
            Debug.Log(elem);
        }
       
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {
        
    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywołano coroutine");
        foreach(Vector3 pos in positions)
        {
            Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            PrzydzielMaterial(this.block);
            yield return new WaitForSeconds(this.delay);
        }
        
        StopCoroutine(GenerujObiekt());
    }

    void PrzydzielMaterial(GameObject obj)
    {
        if(materials.Length > 0)
        {
            Material losowyMaterial = materials[UnityEngine.Random.Range(0, materials.Length)];
            obj.GetComponent<Renderer>().material = losowyMaterial;
        }
    }
}
