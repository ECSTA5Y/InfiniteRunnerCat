using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Image[] lives;
    public Text coinText;
    public Text scoreText; public TextMeshProUGUI failScoreText, highScoreText;
    [Header("Panels")]
    public GameObject pausePanel;
    public GameObject failPanel, highscorePopup;
    [Header("Buttons")]
    public Button homeButton;
    public Button pauseButton, resumeButton;
    private void Start()
    {
        homeButton.onClick.AddListener(delegate
        {
            SoundManager.Instance.StopGameplayLoop();
            SceneManager.LoadScene(0);
        });
        pauseButton.onClick.AddListener(delegate
        {
            pauseButton.gameObject.SetActive(false);
            pausePanel.SetActive(true);
            Player.Instance.GamePaused(true);
        });
        resumeButton.onClick.AddListener(delegate
        {
            pauseButton.gameObject.SetActive(true);
            pausePanel.SetActive(false);
            Player.Instance.GamePaused(false);
        });
    }
    public void UpdateLives(int currentLives)
    {
        for (int i = 0; i < lives.Length; i++)
        {
            lives[i].color = currentLives > i ? Color.white : Color.black;
        }
    }

    public void UpdateCoins(int coint)
    {
        coinText.text = coint.ToString();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
    public void ShowGameEndScreen(int score)
    {
        pauseButton.gameObject.SetActive(false);
        if (PlayerPrefs.GetInt("BestScore", 0) < score) // show high score panel
        {
            highscorePopup.gameObject.SetActive(true);
            ShowScore(highScoreText, score);
        }
        else
        {
            failPanel.gameObject.SetActive(true);
            ShowScore(failScoreText, score);
        }

    }
    void ShowScore(TextMeshProUGUI text, int score)
    {
        int startNumber = 0;
        DOTween.To(() => startNumber, x => startNumber = x, score, 3f)
           .OnUpdate(() =>
           {
               // Update the text to display the current number
               text.text = "Your Score: " + startNumber.ToString();
           })
           .OnComplete(delegate
           {
               Invoke(nameof(GoToMain), 1.5f);
           })
           .SetEase(Ease.Linear);
    }
    void GoToMain()
    {
        SoundManager.Instance.StopGameplayLoop();
        SceneManager.LoadScene(0);
    }
}