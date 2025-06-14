using System;
using UnityEngine;
using static Constants.AnalyticsEvents;


public sealed class GameManager
{
    #region Singleton

    private static readonly GameManager instance = new();

    public static GameManager Instance { get { return instance; } }

    static GameManager() { }

    private GameManager() { }

    #endregion


    private GameData GameData { get; set; }

    public event Action OnGameOver;
    public bool IsGameOver { private set; get; } = false;
    public int GetCurrentScore { private set; get; }
    private float currentScore;

    public void InitializeGameManager()
    {
        IsGameOver = false;
        GameData ??= new();
        GameData?.LoadProgress();       //Configurations are set up in the Firebase Manager..
        GetCurrentScore = 0;

        FirebaseManager.Instance?.InitializeFirebase();
    }

    public void StartGame()
    {
        IsGameOver = false;
        GameData ??= new();
        GameData?.LoadProgress();
        GetCurrentScore = 0;
        currentScore = 0;

        Logger.Log("Game Initialized " + GameData.Progress.Player.LastDistance +
    "  ....... " + GameData.Progress.Player.BestDistance +
    " ...........  " + GameData.Progress.Player.TotalDistance);

        MyAnalytics.LogEvent
            (Events.GAMESTART_EVENT);
    }

    public void GameOver()
    {
        if (IsGameOver)
            return;

        IsGameOver = true;
        GameData.Progress.Player.LastDistance = GetCurrentScore;
        OnGameOver?.Invoke();
        Debug.Log("Game Over:  " + GameData.Progress.Player.LastDistance +
            "  ....... " + GameData.Progress.Player.BestDistance +
            " ...........  " + GameData.Progress.Player.TotalDistance);
        GameData?.SaveProgress();
        MyAnalytics.LogEvent
            (Events.GAMEOVER_EVENT, ParameterName.SCORE, GameData.Progress.Player.LastDistance.ToString());
    }

    public void UpdateScore()
    {
        if (IsGameOver)
            return;

        currentScore += Time.deltaTime * GetLevelConfigData()?.Score?.Factor ?? (float)new Score().Factor;
        GetCurrentScore = (int)currentScore;
    }

    public bool IsBestDistanceBeaten()
    {
        if (GetCurrentScore >= GameData.Progress.Player.BestDistance)
        {
            return true;
        }
        return false;
    }

    public void UpdateRemoteConfigConfigurations(Configuration configuration)
    {
        GameData.Configuration = configuration;
    }

    public Player GetPlayerProgress()
    {
        return GameData?.Progress?.Player ?? new GameData().Progress.Player;
    }

    public LevelData GetLevelConfigData()
    {
        return GameData?.Configuration?.LevelData ?? new GameData().Configuration.LevelData;
    }

    public GameConfigData GetGameConfigData()
    {
        return GameData?.Configuration?.GameConfigData ?? new GameData().Configuration.GameConfigData;
    }

    public AdControl GetAdControlConfigData()
    {
        return GameData?.Configuration?.AdControl ?? new GameData().Configuration.AdControl;
    }
}
