using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrack : MonoBehaviour
{
    public void EndMinigame()
    {
        Coin_Counter.instance.EndMinigame();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            EndMinigame();
        }
    }
}
