using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Car : MonoBehaviour
{

    float speed_Multiplier = 1f;
    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(timer > 0f)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0f;
            speed_Multiplier = 10f;
        }
        transform.Translate(Vector3.forward * speed_Multiplier * Time.deltaTime);

    }

    public void SlowCar()
    {
        timer = 3f;
        speed_Multiplier = speed_Multiplier / 1.5f;
    }
}
