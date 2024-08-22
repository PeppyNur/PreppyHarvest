using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;


public class MiniGameManager : MonoBehaviour
{
    public float gameDuration;
    public TextMeshProUGUI timer,scoreText;
    public Button startButton;
    public Button stopButton;
    public float timeRemaining;
    public bool isGameRunning,isPaused;
    public int score,stopCounter;
    public bool isGameOver = false;
    public float endScene;
    public GameObject finish;

    private void Start()
    {
        timeRemaining = gameDuration;
        isGameRunning = false;
        isPaused = false;
        score = 0;

        startButton.onClick.AddListener(StartGame);
        stopButton.onClick.AddListener(TogglePause);

        stopButton.interactable = false;
        UpdateScoreText();
    }

    private void Update()
    {
        if(isGameRunning &&!isPaused)
        {
            timeRemaining -= Time.deltaTime;
            if(timeRemaining <= 0 )
            {
                timeRemaining = 0;
                isGameOver = true;
                StopGame();
                StartCoroutine(GameOver());
            }

            UpdateTimerText();
        }

    }

    void TogglePause()
    {
        if (stopCounter < 2)
        {
            isPaused = !isPaused;
            stopCounter++;

            if(stopCounter == 2)
            {
                stopButton.interactable = false;
            }
        }
    }
    void StartGame()
    {
        isGameRunning = true;
        timeRemaining = gameDuration;
        score = 0;
        stopCounter = 0;
        isPaused = false;

        startButton.gameObject.SetActive(false);
        stopButton.interactable = true;

        UpdateScoreText();
    }

    void StopGame()
    {
        isGameRunning = false;
        stopButton.interactable= false;
        finish.SetActive(true);
    }

    void UpdateTimerText()
    {
        timer.text = $" {timeRemaining:F2}";
    }

    void UpdateScoreText()
    {
        scoreText.text = $"TOPLANAN MEYVE:{score}";
    }

    public void IncreaseScore(int amount)
    {
        if(isGameRunning&&!isPaused) 
        {
            score += amount;
            UpdateScoreText();
        }
    }

    IEnumerator GameOver()
    {
        while(isGameOver==true)
        {
            yield return new WaitForSeconds(endScene);
            SceneManager.LoadScene("World");

        }
    }
}
