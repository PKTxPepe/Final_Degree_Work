using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marshmallow_Trigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && Marshmallow_Minigame.instance.gameStarted == false)
        {
            Marshmallow_Minigame.instance.StartMinigame();
        }
    }
}
