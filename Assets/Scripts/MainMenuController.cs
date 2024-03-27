using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG;
using DG.Tweening;
public class MainMenuController : MonoBehaviour
{
    public static MainMenuController instance;
    public Button startButton;
    public Button openLeaderboardButton;
    public Button closeLeaderboardButton;
    public Transform leaderboardItemParent;
    public GameObject leaderboardPanel;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        StartCoroutine(Waiter());
        startButton.onClick.AddListener(delegate
        {
            SoundManager.Instance.PlayClickSfx();
            SceneManager.LoadScene(1);
        });
        openLeaderboardButton.onClick.AddListener(delegate
        {
            SoundManager.Instance.PlayClickSfx();
            leaderboardItemParent.localScale = Vector3.zero;
            leaderboardPanel.SetActive(true);
            openLeaderboardButton.gameObject.SetActive(false);
            leaderboardItemParent.DOScale(Vector3.one, .5f)
            .OnComplete(delegate
            {
                closeLeaderboardButton.gameObject.SetActive(true);
            });
        });
        closeLeaderboardButton.onClick.AddListener(delegate
        {
            SoundManager.Instance.PlayClickSfx();
            leaderboardItemParent.localScale = Vector3.one;
            closeLeaderboardButton.gameObject.SetActive(false);
            leaderboardItemParent.DOScale(Vector3.zero, .5f).OnComplete(delegate
            {
                leaderboardPanel.SetActive(false);
                openLeaderboardButton.gameObject.SetActive(true);
            });
        });
    }
    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(2f);
        LeaderboardManager.Instance.ShowScoresUI(leaderboardItemParent);
    }
}