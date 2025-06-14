using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase;
using Firebase.Analytics;
using Firebase.Crashlytics;
using Firebase.Extensions;
using Firebase.RemoteConfig;
using Newtonsoft.Json;
using UnityEngine;
using static Constants;
using static Constants.AnalyticsEvents;

public sealed class FirebaseManager
{
    #region Singleton

    private static readonly FirebaseManager instance = new();

    public static FirebaseManager Instance { get { return instance; } }

    static FirebaseManager() { }

    private FirebaseManager() { }

    #endregion

    private bool isFirebaseInitialized = false;

    private Dictionary<string, object> defaultDict = new()
    {
        {RemoteConfigKeys.GAME_CONFIGURATION_PLAYERPREFS, new Configuration() }
    };

    public void InitializeFirebase()
    {
        if (isFirebaseInitialized) return;

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Result != DependencyStatus.Available)
            {
                Debug.LogError(string.Format("Could not resolve all Firebase dependencies: {0}", task.Result));
                // Firebase Unity SDK is not safe to use here.
            }
            var firebaseApp = FirebaseApp.DefaultInstance;
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
            Crashlytics.ReportUncaughtExceptionsAsFatal = true;
            Logger.Log("Firebase Initialized Successfully...");
            MyAnalytics.LogEvent(Events.GAMEOPENED_EVENT);
            FetchRemoteConfigData();
            isFirebaseInitialized = true;
        });
    }

    private void FetchRemoteConfigData()
    {
        //FirebaseRemoteConfig.DefaultInstance.OnConfigUpdateListener += OnRemoteConfigValueUpdated; //This works only after one fetch..
        SetDefaultValues();
        FetchDataAsync();
    }

    private void OnDestroy()        //Call this on Destroy or Application Quit
    {
        //FirebaseRemoteConfig.DefaultInstance.OnConfigUpdateListener -= OnRemoteConfigValueUpdated;
    }

    private void SetDefaultValues()
    {
        FirebaseRemoteConfig.DefaultInstance.SetDefaultsAsync(defaultDict).ContinueWithOnMainThread(task =>
        {
            var configDataJson = FirebaseRemoteConfig.DefaultInstance.GetValue(RemoteConfigKeys.GAME_CONFIGURATION_PLAYERPREFS).StringValue;
            UpdateConfigurationValues(configDataJson);

            Debug.Log("Default Remote Config Values Setup Completed...");
        });
    }

    private Task FetchDataAsync()
    {
        Debug.Log("Fetching Remote Config data...");
        Task fetchTask = FirebaseRemoteConfig.DefaultInstance.FetchAsync(TimeSpan.Zero); //Timespan can be removed default timespan is 12 hours.
        return fetchTask.ContinueWithOnMainThread(FetchComplete);
    }

    private void FetchComplete(Task fetchTask)
    {
        //If it fails default value is already should be set...
        if (!fetchTask.IsCompleted)
        {
            Debug.LogError("Retrieval hasn't finished.");
            return;
        }

        var remoteConfig = FirebaseRemoteConfig.DefaultInstance;
        var info = remoteConfig.Info;
        if (info.LastFetchStatus != LastFetchStatus.Success)
        {
            Debug.LogError($"{nameof(FetchComplete)} was unsuccessful\n{nameof(info.LastFetchStatus)}: {info.LastFetchStatus}");
            return;
        }

        //Fetch completes here, But its not activated yet...
        ActivateUpdatedValues();
    }

    private void ActivateUpdatedValues() //Call this activate the new values...
    {
        // Fetch successful. Parameter values must be activated to use. //Activation happens after calling this...
        FirebaseRemoteConfig.DefaultInstance.ActivateAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted && !task.IsFaulted && !task.IsCanceled)
            {
                var configDataJson = FirebaseRemoteConfig.DefaultInstance.GetValue(RemoteConfigKeys.GAME_CONFIGURATION_PLAYERPREFS).StringValue;
                UpdateConfigurationValues(configDataJson);

                Debug.Log("Fetch Completed and the updated value is: " + configDataJson);
                Debug.Log($"Remote data loaded and ready for use. Last fetch time{FirebaseRemoteConfig.DefaultInstance.Info.FetchTime}.");
            }
            else
            {
                Debug.LogError("Activation failed.");
            }
        });
    }

    private void OnRemoteConfigValueUpdated(object sender, ConfigUpdateEventArgs e)
    {
        Debug.Log("Remote Config Value Just updated...");
        if (e.Error != RemoteConfigError.None)
        {
            Debug.LogError(String.Format("Error occurred while listening: {0}", e.Error));
            return;
        }
        Debug.Log("Updated Keys are :" + string.Join(", ", e.UpdatedKeys));
        FirebaseRemoteConfig.DefaultInstance.ActivateAsync().ContinueWithOnMainThread(task =>
        {
            var configDataJson = FirebaseRemoteConfig.DefaultInstance.GetValue(RemoteConfigKeys.GAME_CONFIGURATION_PLAYERPREFS).StringValue;
            UpdateConfigurationValues(configDataJson);

            Debug.Log("Remote Config Value Updated and the updated value is: " + configDataJson);
        });
    }

    private void UpdateConfigurationValues(string configDataJson)
    {
        try
        {
            GameManager.Instance.UpdateRemoteConfigConfigurations(JsonConvert.DeserializeObject<Configuration>(configDataJson));
        }
        catch (Exception e)
        {
            MyAnalytics.RecordException(e);
        }
    }
}

/*Newtonsoft Package name:
com.unity.nuget.newtonsoft - json
References:
https://firebase.google.com/docs/remote-config/get-started?platform=unity */
