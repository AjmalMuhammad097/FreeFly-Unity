using System;
using UnityEngine;

public class GameDataManager
{
    private PlayerData playerData;

    public void SavePlayerData()
    {
        if (playerData == null)
        {
            InitializeDefaultPlayerData();
        }

        if (!playerData.IsValid())
        {
            playerData.InitializeDefaults();
        }
        playerData.playerDataVersion = ConstantValues.CurrentPlayerDataVersion; // Set current 

        MyPlayerPrefs.SetJson<PlayerData>(ConstantValues.PLAYERDATA_PLAYERPREFS, playerData);
    }


    public PlayerData LoadPlayerData()
    {
        playerData = MyPlayerPrefs.GetJson<PlayerData>(ConstantValues.PLAYERDATA_PLAYERPREFS);

        if (playerData == null || !playerData.IsValid())
        {
            InitializeDefaultPlayerData();
            SavePlayerData(); // Save the default data immediately to avoid null references later
        }
        else
        {
            if (playerData.playerDataVersion < ConstantValues.CurrentPlayerDataVersion)
            {
                MigratePlayerData(playerData);
            }
        }
        return playerData;
    }

    public void UpdateProgress(int distance)
    {
        if (playerData == null)
        {
            LoadPlayerData();
        }
        playerData.progress.lastDistance = distance;
        playerData.progress.totalDistance += distance;
        if (distance > playerData.progress.highestDistance)
        {
            playerData.progress.highestDistance = distance;
        }
        SavePlayerData();
    }

    private void InitializeDefaultPlayerData()
    {
        playerData = new PlayerData
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
