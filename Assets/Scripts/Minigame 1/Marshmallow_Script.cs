using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marshmallow_Script : MonoBehaviour
{
    public Color currentColor;
    private string assignedColor;
    private string fireColor = null;
    public Color pink;
    public Color green;
    public Color blue;
    public Color white;  
    public Color purple;
    public Color cookedColor;
    public Color burntColor;
    //public string grabbedBy;
    float cookTime = 20;
    float cookTimeGreen;
    float burnTime = 10;
    float timerCook = 0;
    float timerBurn = 0;
    bool cooked = false;
    bool burnt = false;
    bool soundPlayed = false;

    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        //grabbedBy = null;
        AssignRandomColor();
        Debug.Log(currentColor + "   " + assignedColor);
        //switch para decidir el color;
    }

    private void AssignRandomColor()
    {
        float color = UnityEngine.Random.Range(1,6);
        Debug.Log(color);
        switch(color)
        {
            case 1:
                currentColor = pink;
                assignedColor = "Pink";
                rend.material.color = currentColor;
            break;

            case 2:
                currentColor = green;
                assignedColor = "Green";
                rend.material.color = currentColor;
                cookTimeGreen = UnityEngine.Random.Range(3f,25f);
            break;

            case 3:
                currentColor = blue;
                assignedColor = "Blue";
                rend.material.color = currentColor;
            break;

            case 4:
                currentColor = white;
                assignedColor = "White";
                rend.material.color = currentColor;
            break;

            case 5:
                currentColor = purple;
                assignedColor = "Purple";
                rend.material.color = currentColor;
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*while(timer < cookTime)
        {
            /*Color newColor = raw;
            newColor = Mathf.Lerp(raw, cooked, timer / cookTime);
            Debug.Log(timer / cookTime);
            rend.material.SetColor("_Color", newColor);
            timer += 0.001f;
            rend.material.color = Color.Lerp(raw, cooked, timer);
            //timer += Time.deltaTime;
        }*/
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Fire") && fireColor == null)
        {
            fireColor = other.GetComponent<FireWoord_Script>().color;
            Debug.Log("Fire color: " + fireColor);
        }

        else if(other.CompareTag("Floor"))
        {
            Debug.Log("A la puta");
            Destroy(this.gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        switch(fireColor)
        {
            //Left arm
            case "Pink":
                CookPinkMarshmallow();
                break;
            //Random cook
            case "Green":
                CookGreenMarshmallow();
                break;
            //Ping-Pong
            case "Blue":
                CookBlueMarshmallow();
                break;
            //Normal
            case "White":
                CookWhiteMarshmallow();
                break;
            //Right arm
            case "Purple":
                CookPurpleMarshmallow();
                break;
        }
    }

    private void CookPurpleMarshmallow()
    {
        if(assignedColor == fireColor && Marshmallow_Minigame.instance.grabbing_hand == "Right Hand"){
            timerCook+= Time.deltaTime;
            if(timerCook <= cookTime){ // <= 20
                float t = timerCook / cookTime;
                Color actualColor = Color.Lerp(currentColor, cookedColor, t);
                rend.material.color = actualColor;
            }
            else{ // > 20
                cooked = true;
                rend.material.color = cookedColor;
                PlaySound();
                if(timerCook > 30){
                    cooked = false;
                    burnt = true;
                    timerBurn += Time.deltaTime;
                    if(timerBurn <= burnTime){
                        float u = timerBurn / burnTime;
                        Color burnActualColor = Color.Lerp(cookedColor, burntColor, u);
                        rend.material.color = burnActualColor;
                    }
                    else{
                        rend.material.color = burntColor;
                    }
                }
            }
        }
    }

    private void CookWhiteMarshmallow()
    {
        if(assignedColor == fireColor)
        {
            timerCook+= Time.deltaTime;
            if(timerCook <= cookTime){ // <= 20
                float t = timerCook / cookTime;
                Color actualColor = Color.Lerp(currentColor, cookedColor, t);
                rend.material.color = actualColor;
            }
            else{ // > 20
                cooked = true;
                PlaySound();
                rend.material.color = cookedColor;
                if(timerCook > 30){
                    cooked = false;
                    burnt = true;
                    timerBurn += Time.deltaTime;
                    if(timerBurn <= burnTime){
                        float u = timerBurn / burnTime;
                        Color burnActualColor = Color.Lerp(cookedColor, burntColor, u);
                        rend.material.color = burnActualColor;
                    }
                    else{
                        rend.material.color = burntColor;
                    }
                }
            }
            
        }
    }

    private void CookBlueMarshmallow()
    {
        if(assignedColor == fireColor){
                timerCook+= Time.deltaTime;
                if(timerCook <= 1.5f){ // <= 20
                    float t = timerCook / 1.5f;
                    Color actualColor = Color.Lerp(currentColor, cookedColor, t);
                    rend.material.color = actualColor;
                }
                else{ // > 20
                    cooked = true;
                    PlaySound();
                    rend.material.color = cookedColor;
                    if(timerCook > 3.75f){
                        cooked = false;
                        burnt = true;
                        timerBurn += Time.deltaTime;
                        if(timerBurn <= 1.5f){
                            float u = timerBurn / 1.5f;
                            Color burnActualColor = Color.Lerp(cookedColor, burntColor, u);
                            rend.material.color = burnActualColor;
                        }
                        else{
                            rend.material.color = burntColor;
                            timerCook = 0;
                            timerBurn = 0;
                        }
                    }
                }
        }
    }

    private void CookGreenMarshmallow()
    {
        if(assignedColor == fireColor)
        {
            timerCook+= Time.deltaTime;
            if(timerCook <= cookTime){ // <= 20
                float t = timerCook / cookTimeGreen;
                Color actualColor = Color.Lerp(currentColor, cookedColor, t);
                rend.material.color = actualColor;
            }
            else{ // > 20
                cooked = true;
                PlaySound();
                rend.material.color = cookedColor;
                if(timerCook > 30){
                    cooked = false;
                    burnt = true;
                    timerBurn += Time.deltaTime;
                    if(timerBurn <= burnTime){
                        float u = timerBurn / burnTime;
                        Color burnActualColor = Color.Lerp(cookedColor, burntColor, u);
                        rend.material.color = burnActualColor;
                    }
                    else{
                        rend.material.color = burntColor;
                    }
                }
            }
            
        }
    }

    private void CookPinkMarshmallow()
    {
        if(assignedColor == fireColor && Marshmallow_Minigame.instance.grabbing_hand == "Left Hand"){
            timerCook+= Time.deltaTime;
            if(timerCook <= cookTime){ // <= 20
                float t = timerCook / cookTime;
                Color actualColor = Color.Lerp(currentColor, cookedColor, t);
                rend.material.color = actualColor;
            }
            else{ // > 20
                cooked = true;
                PlaySound();
                rend.material.color = cookedColor;
                if(timerCook > 30){
                    cooked = false;
                    burnt = true;
                    timerBurn += Time.deltaTime;
                    if(timerBurn <= burnTime){
                        float u = timerBurn / burnTime;
                        Color burnActualColor = Color.Lerp(cookedColor, burntColor, u);
                        rend.material.color = burnActualColor;
                    }
                    else{
                        rend.material.color = burntColor;
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        fireColor = null;
        Debug.Log("Fire color: " + fireColor);
    }

    public void EatMarshmallow()
    {
        if(cooked == true){
            Marshmallow_Minigame.instance.SetScore(100);
            Destroy(gameObject);
        }
        else if (burnt == true){
            Marshmallow_Minigame.instance.SetScore(-50);
            Destroy(gameObject);
        }
    }
    void PlaySound()
    {
        if(soundPlayed == false)
        {
            soundPlayed = true;
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }
    }
}
