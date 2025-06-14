using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using static Constants;

[Serializable]
public class GameData
{
    public Progress Progress;       //Save Progress In Player Prefs.
    public Configuration Configuration;     //Control Configuration in Remote Config

    public GameData()
    {
        Progress = new();
        Configuration = new();
        //LoadProgress();  //TODO check if i can remove this from other places?
    }

    public void SaveProgress()
    {
        MyPlayerPrefs.SetJson(PlayerPrefsKeys.GAME_PROGRESS_PLAYERPREFS, Progress);
        Debug.Log("Progress Saved Succesfully..");
    }

    public void LoadProgress()
    {
        Progress = MyPlayerPrefs.GetJson<Progress>(PlayerPrefsKeys.GAME_PROGRESS_PLAYERPREFS, new());
        Logger.Log("Progress Loaded Succesfully..");
    }
}

[Serializable]
public class Progress
{
    public int Version = CurrentProgressVersion;
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

            if (lastDistance > BestDistance)
            {
                BestDistance = lastDistance;
            }
            TotalDistance += lastDistance;
        }
    }
    public int BestDistance;
    public int TotalDistance;
}

//Remote Config Datas
#nullable enable
[Serializable]
public class Configuration
{
    [JsonProperty("version")]
    public int? Version = CurrentConfigurationVersion;

    [JsonProperty("level_data")]
    public LevelData? LevelData;

    [JsonProperty("game_config_data")]
    public GameConfigData? GameConfigData;

    [JsonProperty("ad_control")]
    public AdControl? AdControl;

    public Configuration()
    {
        LevelData = new();
        GameConfigData = new();
        AdControl = new();
    }
}

[Serializable]
public class LevelData
{
    [JsonProperty("rocket")]
    public Rocket? Rocket;

    [JsonProperty("platform")]
    public Platform? Platform;

    [JsonProperty("spawner")]
    public Spawner? Spawner;

    [JsonProperty("score")]
    public Score? Score;

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
    [JsonProperty("movement_speed")]
    public float? MovementSpeed = RocketData.MOVEMENT_SPEED;
}

[Serializable]
public class Platform
{
    [JsonProperty("push_force")]
    public float? PushForce = PlatformData.PUSH_FORCE;

    [JsonProperty("width")]
    public float? Width = PlatformData.WIDTH;     //TODO set up later.

}

[Serializable]
public class Spawner
{
    [JsonProperty("initial_platform_count")]
    public int? InitialPlatformCount = SpawnerData.INITIAL_PLATFORM_COUNT;

    [JsonProperty("min_vertical_distance")]
    public float? MinVerticalDistance = SpawnerData.MIN_VERTICAL_DISTANCE;

    [JsonProperty("max_vertical_distance")]
    public float? MaxVerticalDistance = SpawnerData.MAX_VERTICAL_DISTANCE;

    [JsonProperty("super_platform_randomness")]
    public float? SuperPlatformRandomness = SpawnerData.SUPER_PLATFORM_RANDOMNESS;       //TODO Later after setting up the code.
}

[Serializable]
public class Score
{
    [JsonProperty("factor")]
    public float? Factor = ScoreData.FACTOR;
}

[Serializable]
public class GameConfigData
{
    [JsonProperty("url")]
    public Url? Url;

    [JsonProperty("texts")]
    public Texts? Texts;

    [JsonProperty("audio_settings")]
    public AudioSettings? AudioSettings;

    //Put other configs as needed.
    public GameConfigData()
    {
        Url = new();
        Texts = new();
        AudioSettings = new();
    }
}

public class Texts
{
    [JsonProperty("credits")]
    public string? Credits = TextsData.CREDITS;
}

[Serializable]
public class Url
{
    [JsonProperty("social_1")]
    public string? Social1 = UrlData.SOCIAL_1;

    [JsonProperty("social_2")]
    public string? Social2 = UrlData.SOCIAL_2;

    [JsonProperty("social_3")]
    public string? Social3 = UrlData.SOCIAL_3;
}

[Serializable]
public class AudioSettings
{
    [JsonProperty("music_volume")]
    public float? MusicVolume = AudioSettingsData.MUSIC_VOLUME;

    [JsonProperty("sound_volume")]
    public float? SoundVolume = AudioSettingsData.SOUND_VOLUME;
}

[Serializable]
public class AdControl
{
    [JsonProperty("rewarded")]
    public List<Rewarded>? Rewarded;

    [JsonProperty("interstitial")]
    public List<Interstitial>? Interstitial;

    [JsonProperty("banner")]
    public Banner? Banner;
}

[Serializable]
public class Rewarded
{
    [JsonProperty("reward_type")]
    public string? RewardType;

    [JsonProperty("count")]
    public int? Count;

    public Rewarded(string rewardType, int count)
    {
        RewardType = rewardType;
        Count = count;
    }
}

[Serializable]
public class Interstitial
{
    [JsonProperty("show_on_levels")]
    public List<int>? ShowOnLevels;

    public Interstitial(List<int> showOnLevels)
    {
        ShowOnLevels = showOnLevels;
    }
}

[Serializable]
public class Banner
{

}

#nullable disable
