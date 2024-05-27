using System;
using System.Collections.Generic;

[Serializable]
public class GameData
{
    public Progress Progress;       //Save Progress In Player Prefs.
    public Configuration Configuration;     //Control Configuration in Remote Config

    public GameData()
    {
        Progress = new();
        Configuration = new();
    }

    public void SaveProgress()
    {
        MyPlayerPrefs.SetJson(ConstantValues.GAME_PROGRESS_PLAYERPREFS, Progress);
    }

    public void LoadProgress()
    {
        Progress = MyPlayerPrefs.GetJson<Progress>(ConstantValues.GAME_PROGRESS_PLAYERPREFS);
    }

    public void SaveConfiguration()     //For Backup
    {
        MyPlayerPrefs.SetJson(ConstantValues.GAME_CONFIGURATION_PLAYERPREFS, Configuration);
    }

    public void LoadConfiguration()
    {
        Configuration = MyPlayerPrefs.GetJson<Configuration>(ConstantValues.GAME_CONFIGURATION_PLAYERPREFS);
    }
}

[Serializable]
public class Progress
{
    public int Version = 1;
    public Player Player;
    public Progress()
    {
        Player = new();
    }
}

[Serializable]
public class Player
{
    private int lastDistance;
    public int LastDistance
    {
        get { return lastDistance; }
        set
        {
            lastDistance = value;
            if (value > BestDistance)
            {
                BestDistance = value;
            }
            TotalDistance += value;
        }
    }
    public int BestDistance;
    public int TotalDistance;
}

[Serializable]
public class Configuration
{
    public int Version = 1;
    public LevelData LevelData;
    public AdControl AdControl;
    public Configuration()
    {
        LevelData = new();
        AdControl = new();
    }
}

[Serializable]
public class LevelData
{
    public Rocket Rocket;
    public Platform Platform;
    public Spawner Spawner;
    public Score Score;
    public LevelData()
    {
        Rocket = new();
        Platform = new();
        Spawner = new();
        Score = new();
    }
}

[Serializable]
public class Rocket
{
    public float Speed;
}

[Serializable]
public class Platform
{
    public float Velocity;
    public float Size;
}

[Serializable]
public class Spawner
{
    public float Interval;
    public float SuperPlatformRandomness;
}

[Serializable]
public class Score
{
    public float Factor;
}

[Serializable]
public class AdControl
{
    public List<Rewarded> Rewarded;
    public List<Interstitial> Interstitial;
    public Banner Banner;
}

[Serializable]
public class Rewarded
{
    public string RewardType;
    public int Count;

    public Rewarded(string rewardType, int count)
    {
        RewardType = rewardType;
        Count = count;
    }
}

[Serializable]
public class Interstitial
{
    public List<int> ShowOnLevels;

    public Interstitial(List<int> showOnLevels)
    {
        ShowOnLevels = showOnLevels;
    }
}

[Serializable]
public class Banner
{

}
