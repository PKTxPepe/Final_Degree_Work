using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Pressed : MonoBehaviour
{
    private AudioSource sound;
    public int button_ID;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSound()
    {
        if(Buttons_Minigame.instance.gameStarted == false)
        {
            sound.Play();
        }
        else
        {
            sound.Play();
            StartCoroutine(Wait());
        }
    }

    public void StartMinigame()
    {
        Buttons_Minigame.instance.StartMinigame();
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        Buttons_Minigame.instance.CheckSound(button_ID);
    }
}
