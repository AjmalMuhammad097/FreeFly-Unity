using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    public int playerDataVersion;
    public string playerId;
    public string playerName;
    public ProgressData progress;
    public SettingsData settings;

    [System.Serializable]
    public class ProgressData
    {
        public int lastDistance;
        public int highestDistance;
        public int totalDistance;
        public int boostsUsed;
    }

    [System.Serializable]
    public class SettingsData
    {
        public bool musicSetting;
        public bool soundEffectSetting;
    }

    // Validation method to ensure data integrity
    public bool IsValid()
    {
        if (string.IsNullOrEmpty(playerId) || string.IsNullOrEmpty(playerName))
        {
            return false;
        }

        if (progress == null || settings == null)
        {
            return false;
        }

        if (progress.lastDistance < 0 || progress.highestDistance < 0 || progress.totalDistance < 0 || progress.boostsUsed < 0)
        {
            return false;
        }

        return true;
    }

    // Method to initialize default values
    public void InitializeDefaults()
    {
        if (string.IsNullOrEmpty(playerId)) playerId = Guid.NewGuid().ToString();
        if (string.IsNullOrEmpty(playerName)) playerName = "DefaultPlayer";
        progress ??= new ProgressData();
        settings ??= new SettingsData();

        progress.lastDistance = Mathf.Max(0, progress.lastDistance);
        progress.highestDistance = Mathf.Max(0, progress.highestDistance);
        progress.totalDistance = Mathf.Max(0, progress.totalDistance);
        progress.boostsUsed = Mathf.Max(0, progress.boostsUsed);

        // Assuming true is the default safe value for settings
        settings.musicSetting = true;
        settings.soundEffectSetting = true;
    }
}

