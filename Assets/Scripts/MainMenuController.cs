using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG;
using DG.Tweening;
using TMPro;
public class MainMenuController : MonoBehaviour
{
    public static MainMenuController instance;
    public Button startButton;
    public Button openUpdateUsernameButton;
    public Button confirmRenameButton;
    public Button openLeaderboardButton;
    public Button closeLeaderboardButton;
    public Transform leaderboardItemParent;
    public GameObject leaderboardPanel;
    public GameObject updateUsernamePanel;
    public GameObject errorUsernamePanel;
    public TextMeshProUGUI[] usernameText;
    public TMP_InputField renameInputField;

    public Button discordButton;
    public Button xButton;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        //StartCoroutine(Waiter());
        startButton.onClick.AddListener(delegate
        {
            SoundManager.Instance.PlayClickSfx();
            SceneManager.LoadScene(1);
        });
        openLeaderboardButton.onClick.AddListener(delegate
        {
            for (int i = 0; i < leaderboardItemParent.childCount; i++)
                Destroy(leaderboardItemParent.GetChild(i).gameObject);
            SoundManager.Instance.PlayClickSfx();
            leaderboardItemParent.localScale = Vector3.zero;
            leaderboardPanel.SetActive(true);
            openLeaderboardButton.gameObject.SetActive(false);
            leaderboardItemParent.DOScale(Vector3.one, .5f)
            .OnComplete(delegate
            {
                closeLeaderboardButton.gameObject.SetActive(true);
                LeaderboardManager.Instance.ShowScoresUI(leaderboardItemParent);
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
        openUpdateUsernameButton.onClick.AddListener(delegate
        {
            SoundManager.Instance.PlayClickSfx();
            updateUsernamePanel.SetActive(true);
            leaderboardPanel.SetActive(false);
        });
        confirmRenameButton.onClick.AddListener(delegate
        {
            SoundManager.Instance.PlayClickSfx();
            updateUsernamePanel.SetActive(false);
            if (renameInputField.text != "")
            {
                LeaderboardManager.Instance.RenamePlayer(renameInputField.text);
                UpdateUsernameUI(renameInputField.text);
            }
            else
            {
                updateUsernamePanel.SetActive(false);
                errorUsernamePanel.SetActive(true);
            }
        });
        discordButton.onClick.AddListener(delegate
        {
            SoundManager.Instance.PlayClickSfx();
            Application.OpenURL("https://discord.gg/VRC3pfy76v");
        });
        xButton.onClick.AddListener(delegate
        {
            SoundManager.Instance.PlayClickSfx();
            Application.OpenURL("https://twitter.com/adarunnerz");
        });
    }
    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(2f);
        LeaderboardManager.Instance.ShowScoresUI(leaderboardItemParent);
    }
    public void UpdateUsernameUI(string str)
    {
        foreach (var item in usernameText)
        {
            item.text = str;
        }
    }
}