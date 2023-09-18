using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerButtons : MonoBehaviour
{
    [SerializeField] private Image uiFill;
    [SerializeField] private TMP_Text uiText;

    public int duration;
    private int remainingDuration;

    void Start()
    {
        Begin(duration);
    }

    private void Begin(int seconds)
    {
        remainingDuration = seconds;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while(remainingDuration >= 0)
        {
            uiText.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
            uiFill.fillAmount = Mathf.InverseLerp(0, duration, remainingDuration);
            remainingDuration--;
            Debug.Log(uiFill.fillAmount);
            yield return new WaitForSeconds(1f);
        }
        FinishMinigame();
    }

    private void FinishMinigame()
    {
        Buttons_Minigame.instance.EndMinigame();
    }
}
