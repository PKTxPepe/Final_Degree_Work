using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin_Counter : MonoBehaviour
{
    public static Coin_Counter instance;
    public GameObject player1;
    public GameObject player2;
    public GameObject camera1;
    public GameObject camera2;
    public GameObject car;
    public GameObject teleport;
    public GameObject easyTrack;
    public GameObject mediumTrack;
    public GameObject hardTrack;
    public GameObject canvasResults;
    public GameObject canvasStats;
    public GameObject restartButton;
    public FadeScreen fadeScreen;
    public FadeScreen fadeScreen2;
    public TMP_Text scoreText;
    public TMP_Text currentScoreText;
    public TMP_Text maxScoreText;
    public TMP_Text beatRecordText;
    public TMP_Text crashesText;
    public TMP_Text secondsText;
    public TMP_Text beatLevelText;
    public bool reached_Goal = false;
    bool aux = false;
    public int scoreToAchieve;
    public int timeToAchieve;
    public int currentScore = 0;
    public int currentTime = 0;
    public int maxScore = 0;
    public int crashes = 0;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        player2.SetActive(false);
        maxScore = PlayerPrefs.GetInt("MaxRecordMG2");
        car.SetActive(false);
        player1.SetActive(true);
    }

    public void IncreaseScore(int value)
    {
        currentScore += value;
        scoreText.text = "Score: " + currentScore.ToString();
    }

    public void EndMinigame()
    {
        if(aux == false){
            aux = true;
            Debug.Log("A tu casa crack");
            //cambiar dentro de una función
            //ChangeActivePlayer(reached_Goal);
            StartCoroutine(GoToStatsRoutine());
            //player1.SetActive(true);
            //camera1.SetActive(true);
            reached_Goal = true;
        }
    }

    public void StartMinigame()
    {
        scoreText.text = "Score: " + currentScore.ToString();
        camera1.SetActive(false);
        player1.SetActive(false);
        player1.transform.position = teleport.transform.position;
        player2.SetActive(true);
        camera2.SetActive(true);
        car.SetActive(true);
    }

    public void SetMinigameDifficulty(string difficulty){
        Debug.Log("Entro");
        switch(difficulty){
            case "Easy":
            Debug.Log("Difficulty set to: Easy");
            //sounds = soundsEasy;
            scoreToAchieve = 750;
            timeToAchieve = 90;
            mediumTrack.SetActive(false);
            hardTrack.SetActive(false);
            easyTrack.SetActive(true);
            break;
            case "Medium":
            Debug.Log("Difficulty set to: Medium");
            //sounds = soundsMedium;
            scoreToAchieve = 1500;
            timeToAchieve = 120;
            easyTrack.SetActive(false);
            hardTrack.SetActive(false);
            mediumTrack.SetActive(true);
            break;
            case "Hard":
            Debug.Log("Difficulty set to: Hard");
            //sounds = soundsHard;
            scoreToAchieve = 2000;
            timeToAchieve = 90;
            easyTrack.SetActive(false);
            mediumTrack.SetActive(false);
            hardTrack.SetActive(true);
            break;

        }
    }

    void ChangeActivePlayer(bool b)
    {
        if(b == false){
            reached_Goal = true;
            car.SetActive(false);
            camera2.SetActive(false);
            player1.SetActive(true);
            camera1.SetActive(true);
        }
    }

    void CheckResults()
    {
        currentScoreText.SetText(currentScore.ToString() + " Points");
        maxScoreText.SetText(maxScore.ToString() + " Points");
        if(currentScore > maxScore)
        {
            maxScore = currentScore;
            PlayerPrefs.SetInt("MaxRecordMG2", maxScore);
        }
        else
        {
            beatRecordText.SetText("Good job! Keep it up!");
        }
    }

    void CheckStats()
    {
        crashesText.SetText(crashes.ToString() + " Times");
        secondsText.SetText(currentTime.ToString() + " Seconds");
        if(currentScore >= scoreToAchieve && currentTime <= timeToAchieve)
        {
            beatLevelText.SetText("Congratulations! You cleared the level!");
        }
        else
        {
            beatLevelText.SetText("You did not clear the level, but you will do better next time!");
        }
    }

    IEnumerator GoToStatsRoutine()
    {
        fadeScreen2.FadeOut();
        yield return new WaitForSeconds(fadeScreen.FadeDuration);
        camera2.SetActive(false);
        car.SetActive(false);
        player1.SetActive(true);
        camera1.SetActive(true);
        canvasResults.SetActive(true);
        canvasStats.SetActive(true);
        restartButton.GetComponent<Canvas>().enabled = true;
        CheckResults();
        CheckStats();

        fadeScreen.FadeIn();
    }
}
