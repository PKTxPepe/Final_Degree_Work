using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attach_Stick : MonoBehaviour
{
    private SphereCollider sphere;
    // Start is called before the first frame update
    void Start()
    {
        sphere = GetComponent<SphereCollider>();
        if(sphere != null) Debug.Log("HABEMUS ESFERA");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
