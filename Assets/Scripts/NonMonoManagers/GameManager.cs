using System;
using UnityEngine;

public sealed class GameManager
{
    #region Singleton

    private static readonly GameManager instance = new();

    public static GameManager Instance { get { return instance; } }

    static GameManager() { }

    private GameManager()
    {
        InitializeGameManager();
    }

    #endregion


    public GameData GameData = new();

    public event Action OnGameOver;
    public bool IsGameOver { private set; get; }
    public int GetCurrentScore { private set; get; }
    private float currentScore;

    public void InitializeGameManager()
    {
        IsGameOver = false;
        GameData.LoadProgress();
        GetCurrentScore = 0;
        Debug.Log("Game Initialized " + GameData.Progress.Player.LastDistance +
            "  ....... " + GameData.Progress.Player.BestDistance +
            " ...........  " + GameData.Progress.Player.TotalDistance);
    }

    public void GameOver()
    {
        if (IsGameOver)
            return;

        Debug.Log("GameOver");
        IsGameOver = true;
        GameData.Progress.Player.LastDistance = GetCurrentScore;
        OnGameOver?.Invoke();
        Debug.Log("Game Initialized " + GameData.Progress.Player.LastDistance +
    "  ....... " + GameData.Progress.Player.BestDistance +
    " ...........  " + GameData.Progress.Player.TotalDistance);
        GameData.SaveProgress();
    }

    public void ResetGame()
    {
        IsGameOver = false;
        GetCurrentScore = 0;
        Debug.Log("Game Initialized " + GameData.Progress.Player.LastDistance +
    "  ....... " + GameData.Progress.Player.BestDistance +
    " ...........  " + GameData.Progress.Player.TotalDistance);
    }

    public void UpdateScore()
    {
        if (IsGameOver)
            return;

        currentScore += Time.deltaTime * ConstantValues.SCORE_FACTOR;
        GetCurrentScore = (int)currentScore;
        Debug.Log("Get current score: " + (int)currentScore);
    }
}
