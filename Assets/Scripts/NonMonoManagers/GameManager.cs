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

    public void InitializeGameManger()
    {
        
    }

    private GameData gameData = new();

    public bool IsGameOver { private set; get; }
    public int GetCurrentScore { private set; get; }

    public event Action<GameData> OnGameOver; 

    public void GameOver(GameData gameData)
    {
        this.gameData = gameData;
        IsGameOver = true;
        OnGameOver.Invoke(this.gameData);
    }

    public void ResetGame()
    {
        IsGameOver = false;
    }
}
