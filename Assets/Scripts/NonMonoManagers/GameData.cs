using System;
using UnityEngine;

public class GameData
{
    public PlayerData PlayerData;

    public void SavePlayerData()
    {
        if (PlayerData == null)
        {
            InitializeDefaultPlayerData();
        }

        if (!PlayerData.IsValid())
        {
            PlayerData.InitializeDefaults();
        }
        PlayerData.playerDataVersion = ConstantValues.CurrentPlayerDataVersion; // Set current 

        MyPlayerPrefs.SetJson<PlayerData>(ConstantValues.PLAYERDATA_PLAYERPREFS, PlayerData);
    }


    public PlayerData LoadPlayerData()
    {
        PlayerData = MyPlayerPrefs.GetJson<PlayerData>(ConstantValues.PLAYERDATA_PLAYERPREFS);

        if (PlayerData == null || !PlayerData.IsValid())
        {
            InitializeDefaultPlayerData();
            SavePlayerData(); // Save the default data immediately to avoid null references later
        }
        else
        {
            if (PlayerData.playerDataVersion < ConstantValues.CurrentPlayerDataVersion)
            {
                MigratePlayerData(PlayerData);
            }
        }
        return PlayerData;
    }

    public void UpdateProgress(int distance)
    {
        if (PlayerData == null)
        {
            LoadPlayerData();
        }
        PlayerData.progress.lastDistance = distance;
        PlayerData.progress.totalDistance += distance;
        if (distance > PlayerData.progress.highestDistance)
        {
            PlayerData.progress.highestDistance = distance;
        }
        SavePlayerData();
    }

    private void InitializeDefaultPlayerData()
    {
        PlayerData = new PlayerData
        {
            playerDataVersion = ConstantValues.CurrentPlayerDataVersion,
            playerId = Guid.NewGuid().ToString(), // Assign a new unique ID
            playerName = "DefaultPlayer",
            progress = new PlayerData.ProgressData
            {
                lastDistance = 0,
                highestDistance = 0,
                totalDistance = 0,
                boostsUsed = 0
            },
            settings = new PlayerData.SettingsData
            {
                musicSetting = true,
                soundEffectSetting = true
            }
        };
    }

    private void MigratePlayerData(PlayerData oldData)
    {
        // Example migration logic
        if (oldData.playerDataVersion == 0)
        {
            // Assuming version 0 did not have boostsUsed field and added it in version 1
            oldData.progress.boostsUsed = 0;
            oldData.playerDataVersion = 1; // Update to the next version
        }

        // Handle further migrations if needed

        SavePlayerData(); // Save migrated data
    }

}
