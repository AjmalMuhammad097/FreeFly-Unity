using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[Serializable]
public class GameData
{
    public int LastScore
    {
        set
        {
            //Might invoke event to update scores.
            CalculateBestScore(value);
        }
    }
    public int BestScore { get; private set; }
    public int TotalScore { get; private set; }

    public GameData()
    {
        LastScore = MyPlayerPrefs.GetInt(ConstantValues.LASTSCORE_PLAYERPREFS);
        BestScore = MyPlayerPrefs.GetInt(ConstantValues.BESTSCORE_PLAYERPREFS);
        TotalScore = MyPlayerPrefs.GetInt(ConstantValues.TOTALSCORE_PLAYERPREFS);
    }

    private void CalculateBestScore(int lastScore)
    {
        TotalScore += lastScore;
        LastScore = lastScore;

        if (lastScore > BestScore)
        {
            BestScore = lastScore;
            MyPlayerPrefs.SetInt(ConstantValues.BESTSCORE_PLAYERPREFS, lastScore);
        }

        MyPlayerPrefs.SetInt(ConstantValues.LASTSCORE_PLAYERPREFS, lastScore);
        MyPlayerPrefs.SetInt(ConstantValues.TOTALSCORE_PLAYERPREFS, TotalScore);
    }
}
