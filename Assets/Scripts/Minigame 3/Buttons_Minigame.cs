using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Buttons_Minigame : MonoBehaviour
{
    public static Buttons_Minigame instance;
    public AudioSource[] sounds;
    public AudioSource[] soundsEasy;
    public AudioSource[] soundsMedium;
    public AudioSource[] soundsHard;
    [SerializeField] AudioSource successSound;
    [SerializeField] AudioSource failSound;
    public GameObject easyButtons;
    public GameObject mediumButtons;
    public GameObject hardButtons;
    public GameObject restartButton;
    public GameObject timer;
    public GameObject resultsScreen;
    public GameObject statsScreen;
    public int indexCurrentSound;
    int maxScore;
    int pointsToAchieve;
    int failsToAchieve;
    int puntos = 0;
    int fallos = 0;
    public bool gameStarted = false;

    public TMP_Text scoreText;
    public TMP_Text currentScoreText;
    public TMP_Text recordScoreText;
    public TMP_Text beatRecordText;
    public TMP_Text correctlyGuessed;
    public TMP_Text failedGuesses;
    public TMP_Text beatLevelText;


    
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
        maxScore = PlayerPrefs.GetInt("MaxRecordMG3");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayRound()
    {
        indexCurrentSound = Random.Range(0, sounds.Length);
        sounds[indexCurrentSound].Play();
    }

    public void CheckSound(int id)
    {
        sounds[indexCurrentSound].Stop();
        if(id == indexCurrentSound)
        {
            successSound.Play();
            puntos++;
            scoreText.text = "Score: " + puntos.ToString();
            StartCoroutine(Wait());
        }
        else
        {
            failSound.Play();
            fallos++;
            StartCoroutine(Wait());
        }
    }

    public void SetMinigameDifficulty(string difficulty){
        switch(difficulty){
            case "Easy":
            Debug.Log("Difficulty set to: Easy");
            sounds = soundsEasy;
            easyButtons.SetActive(true);
            mediumButtons.SetActive(false);
            hardButtons.SetActive(false);
            pointsToAchieve = 20;
            failsToAchieve = 5;
            break;
            case "Medium":
            Debug.Log("Difficulty set to: Medium");
            sounds = soundsEasy;
            easyButtons.SetActive(true);
            mediumButtons.SetActive(false);
            hardButtons.SetActive(false);
            pointsToAchieve = 25;
            failsToAchieve = 3;
            break;
            case "Hard":
            Debug.Log("Difficulty set to: Hard");
            sounds = soundsHard;
            easyButtons.SetActive(false);
            mediumButtons.SetActive(false);
            hardButtons.SetActive(true);
            pointsToAchieve = 30;
            failsToAchieve = 1;
            break;

        }
    }

    public void StartMinigame()
    {

        gameStarted = true;
        timer.SetActive(true);
        scoreText.text = "Score: 0";
        PlayRound();
    }

    public void EndMinigame()
    {
        Debug.Log("Se acabó");
        gameStarted = false;
        timer.SetActive(false);
        resultsScreen.SetActive(true);
        statsScreen.SetActive(true);
        restartButton.GetComponent<Canvas>().enabled = true;
        CheckRecord();
        CheckStats();
    }

    public void CheckRecord()
    {
        currentScoreText.SetText(puntos.ToString());
        recordScoreText.SetText(maxScore.ToString());
        if(puntos > maxScore)
        {
            maxScore = puntos;
            PlayerPrefs.SetInt("MaxRecordMG3", maxScore);
        }
        else
        {
            beatRecordText.SetText("Good job! Keep it up!");
        }

    }

    public void CheckStats()
    {
        correctlyGuessed.SetText(puntos.ToString() + " Sounds");
        failedGuesses.SetText(fallos.ToString() + " Times");
        if(puntos >= pointsToAchieve && fallos <= failsToAchieve)
        {
            beatLevelText.SetText("Congratulations! You cleared the level!");
        }
        else
        {
            beatLevelText.SetText("You did not clear the level, but you will do better next time!");
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        PlayRound();
    }

    
}
