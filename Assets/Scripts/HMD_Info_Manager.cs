using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HMD_Info_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Device Active? " + XRSettings.isDeviceActive);
        Debug.Log("Device name is " + XRSettings.loadedDeviceName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
