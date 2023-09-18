using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowCar : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Marikong");
            Move_Car car = other.gameObject.GetComponentInParent<Move_Car>();
            Coin_Counter.instance.crashes++;
            car.SlowCar();
        }
    }
}
