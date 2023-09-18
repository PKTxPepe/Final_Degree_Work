using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Script : MonoBehaviour
{
    public int value;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("HOLA?" + other.gameObject.tag);
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("hola");
            Destroy(gameObject);
            Coin_Counter.instance.IncreaseScore(value);
        }
    }
}
