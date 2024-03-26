using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Leaderboards;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    public static LeaderboardManager Instance;
    // Create a leaderboard with this ID in the Unity Cloud Dashboard
    const string LeaderboardId = "InfiniteRunner_Leaderboard";
    string VersionId { get; set; }
    int Offset { get; set; }
    int Limit { get; set; }
    int RangeLimit { get; set; }
    List<string> FriendIds { get; set; }


    public string playerName;
    public ScoreItem scoreItemPrefab;
    async void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            await UnityServices.InitializeAsync();
            await SignInAnonymously();
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        //addScoreBtn.onClick.AddListener(delegate
        //{
        //    AddScore();
        //});
        //showAllScoreBtn.onClick.AddListener(delegate
        //{
        //    ShowScoresUI();
        //});
        //renamePlayerBtn.onClick.AddListener(delegate
        //{
        //    RenamePlayer();
        //});
    }

    async Task SignInAnonymously()
    {
        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed in as: " + AuthenticationService.Instance.PlayerId);
        };
        AuthenticationService.Instance.SignInFailed += s =>
        {
            // Take some action here...
            Debug.Log(s);
        };

        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }
    public void RenamePlayer()
    {
        if (playerName != null)
            AuthenticationService.Instance.UpdatePlayerNameAsync(playerName);
    }
    public async void AddScore(int score)
    {

        var scoreResponse = await LeaderboardsService.Instance.AddPlayerScoreAsync(LeaderboardId, score);
        Debug.Log(JsonConvert.SerializeObject(scoreResponse));
    }

    public async void GetScores()
    {
        var scoresResponse =
            await LeaderboardsService.Instance.GetScoresAsync(LeaderboardId);
        Debug.Log(JsonConvert.SerializeObject(scoresResponse));
    }
    public async void ShowScoresUI(Transform scoreItemParent)
    {
        bool playerInTopTen = false;
        for (int i = 0; i < scoreItemParent.childCount; i++)
            Destroy(scoreItemParent.GetChild(i).gameObject);
        await LeaderboardsService.Instance.AddPlayerScoreAsync(LeaderboardId, 0);
        var scoreResponseCurrent =
          await LeaderboardsService.Instance.GetPlayerScoreAsync(LeaderboardId);
        int currentRank = scoreResponseCurrent.Rank;
        var scoresResponse =
          await LeaderboardsService.Instance.GetScoresAsync(LeaderboardId);
        for (int i = 0; i < scoresResponse.Results.Count; i++)
        {
            ScoreItem si = Instantiate(scoreItemPrefab, scoreItemParent);
            si.SetScoreItem(scoresResponse.Results[i].PlayerName, scoresResponse.Results[i].Rank, scoresResponse.Results[i].Score);
            if (i == currentRank)
            {
                playerInTopTen = true;
                si.SetAsCurrentPlayer();
            }
        }
        if (!playerInTopTen)
        {
            ScoreItem si = Instantiate(scoreItemPrefab, scoreItemParent);
            si.SetScoreItem(scoreResponseCurrent.PlayerName, scoreResponseCurrent.Rank, scoreResponseCurrent.Score);
            si.SetAsCurrentPlayer();
        }
    }
    public async void GetPaginatedScores()
    {
        Offset = 10;
        Limit = 10;
        var scoresResponse =
            await LeaderboardsService.Instance.GetScoresAsync(LeaderboardId, new GetScoresOptions { Offset = Offset, Limit = Limit });
        Debug.Log(JsonConvert.SerializeObject(scoresResponse));
    }

    public async void GetPlayerScore()
    {
        var scoreResponse =
            await LeaderboardsService.Instance.GetPlayerScoreAsync(LeaderboardId);
        Debug.Log(JsonConvert.SerializeObject(scoreResponse));
    }

    public async void GetVersionScores()
    {
        var versionScoresResponse =
            await LeaderboardsService.Instance.GetVersionScoresAsync(LeaderboardId, VersionId);
        Debug.Log(JsonConvert.SerializeObject(versionScoresResponse));
    }
}