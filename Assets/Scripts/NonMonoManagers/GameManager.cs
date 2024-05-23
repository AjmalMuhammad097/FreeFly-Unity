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


    private GameDataManager gameDataManager = new();

    public event Action OnGameOver;
    public bool IsGameOver { private set; get; }
    public int GetCurrentScore { private set; get; }
    private float currentScore;

    public void InitializeGameManager()
    {
        IsGameOver = false;
        GetCurrentScore = 0;
        gameDataManager.LoadPlayerData();
    }

    public void GameOver()
    {
        if (IsGameOver)
            return;

        Debug.Log("GameOver");
        IsGameOver = true;
        gameDataManager.UpdateProgress(GetCurrentScore);
        OnGameOver?.Invoke();
        gameDataManager.SavePlayerData();
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
