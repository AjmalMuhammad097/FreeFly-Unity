using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameManager
{
    #region Singleton

    private static readonly GameManager instance = new();

    public static GameManager Instance { get { return instance; } }

    static GameManager() { }

    private GameManager() { }

    #endregion


    public GameData GameData = new();

    public event Action OnGameOver;
    public bool IsGameOver { private set; get; }
    public int GetCurrentScore { private set; get; }
    private float currentScore;

    public void InitializeGameManager()
    {
        IsGameOver = false;
        GetCurrentScore = 0;
        GameData.LoadProgress();
    }

    public void GameOver()
    {
        if (IsGameOver)
            return;

        Debug.Log("GameOver");
        IsGameOver = true;
        GameData.Progress.Player.LastScore = GetCurrentScore;
        OnGameOver?.Invoke();
        GameData.SaveProgress();
        ResetGame();    //TODO call this when the game resetted.
    }

    public void ResetGame()
    {
        IsGameOver = false;
        GetCurrentScore = 0;
    }

    public void UpdateScore()
    {
        if (IsGameOver)
            return;

        currentScore += Time.deltaTime * ConstantValues.SCORE_FACTOR;
        GetCurrentScore = (int)currentScore;
        Debug.Log("Get current score: " + GetCurrentScore);
    }
}
