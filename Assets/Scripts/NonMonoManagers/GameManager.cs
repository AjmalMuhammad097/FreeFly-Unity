using System;
using UnityEngine;

public sealed class GameManager
{
    #region Singleton

    private static readonly GameManager instance = new();

    public static GameManager Instance { get { return instance; } }

    static GameManager() { }

    private GameManager() { }

    #endregion


    public GameData GameData;

    public event Action OnGameOver;
    public bool IsGameOver { private set; get; }
    public int GetCurrentScore { private set; get; }
    private float currentScore;

    public void InitializeGameManager()
    {
        IsGameOver = false;
        GameData ??= new();
        GameData.LoadProgress();
        GetCurrentScore = 0;
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
        GameData.SaveProgress();
    }

    public void ResetGame()
    {
        IsGameOver = false;
        GetCurrentScore = 0;
        currentScore = 0;

        Debug.Log("Game Initialized " + GameData.Progress.Player.LastDistance +
    "  ....... " + GameData.Progress.Player.BestDistance +
    " ...........  " + GameData.Progress.Player.TotalDistance);
    }

    public void UpdateScore()
    {
        if (IsGameOver)
            return;

        currentScore += Time.deltaTime * ConstantValues.SCORE_FACTOR;       //Fetch from Remote Config
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
}
