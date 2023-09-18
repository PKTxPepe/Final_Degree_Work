using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Marshmallow_Minigame : MonoBehaviour
{
    public static Marshmallow_Minigame instance;

    public string grabbing_hand = null;
    public GameObject restartButton;

    public GameObject canvasGame;
    public GameObject canvasResults;

    public int score = 0;
    public int maxScore = 0;

    public bool gameStarted = false;

    public TMP_Text scoreText;
    public TMP_Text currentScoreText;
    public TMP_Text recordScoreText;
    public TMP_Text beatRecordText;
    
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        maxScore = PlayerPrefs.GetInt("MaxRecordMG1");
        //StartMinigame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartMinigame()
    {
        canvasGame.SetActive(true);
        scoreText.text = "Score: 0";
    }

    public void SetScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score.ToString();
    }

    public void SetMinigameDifficulty(string difficulty)
    {
        switch(difficulty){
            case "Easy":
            Debug.Log("Difficulty set to: Easy");
            break;
            case "Medium":
            Debug.Log("Difficulty set to: Medium");
            break;
            case "Hard":
            Debug.Log("Difficulty set to: Hard");
            break;
        }
    }

    public void EndMinigame()
    {
        Debug.Log("BRUUUUUH");
        canvasGame.SetActive(false);
        canvasResults.SetActive(true);
        restartButton.GetComponent<Canvas>().enabled = true;
        currentScoreText.SetText(score.ToString());
        recordScoreText.SetText(maxScore.ToString());
        if(score > maxScore){
            //Hacer mucho texto
            maxScore = score;
            PlayerPrefs.SetInt("MaxRecordMG1", maxScore);
        }
        else{
            beatRecordText.SetText("Good job! Keep it up!");
        }
    }


}
