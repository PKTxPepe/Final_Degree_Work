using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cronometer : MonoBehaviour
{
    [SerializeField] TMP_Text uiText;
    int time;

    void Start()
    {
        Begin();   
    }

    void Begin()
    {
        StartCoroutine(UpdateTimer());
    }

    IEnumerator UpdateTimer()
    {
        while(Coin_Counter.instance.reached_Goal == false)
        {
            uiText.text = $"{time / 60:00}:{time % 60:00}";
            time++;
            Coin_Counter.instance.currentTime = time;
            Debug.Log(time);
            yield return new WaitForSeconds(1f);
        }
    }
}
