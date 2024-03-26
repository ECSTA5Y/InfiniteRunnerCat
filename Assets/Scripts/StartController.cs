using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartController : MonoBehaviour
{
    public Button startButton;
    public Transform leaderboardItemParent;
  
    private void Start()
    {
        StartCoroutine(Waiter());
        startButton.onClick.AddListener(delegate
        {
            SoundManager.Instance.PlayClickSfx();
            SceneManager.LoadScene(1);
        });
        Invoke(nameof(PlayDogBark),19.6f);
    }
    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(0.5f);
        LeaderboardManager.Instance.ShowScoresUI(leaderboardItemParent);
    }
    void PlayDogBark()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
            SoundManager.Instance.PlayDogBarkSfx();
    }
}