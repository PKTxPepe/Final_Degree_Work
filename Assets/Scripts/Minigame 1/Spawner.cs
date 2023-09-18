using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnMarshmallow()
    {
        Debug.Log("SPAWNED");
        Instantiate(objectToSpawn, transform.position, transform.rotation);
        objectToSpawn.transform.Translate(0, 1, 0);
    }
}
