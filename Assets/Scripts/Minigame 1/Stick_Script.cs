using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick_Script : MonoBehaviour
{

    public string grabbedBy;
    // Start is called before the first frame update
    void Start()
    {
        grabbedBy = null;
        Debug.Log("Stick: " + grabbedBy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
