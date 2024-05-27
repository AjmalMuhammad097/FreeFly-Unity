using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public static class MyPlayerPrefs
{
    public static void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public static int GetInt(string key, int defaultValue = 0)
    {
        return PlayerPrefs.GetInt(key, defaultValue);
    }

    public static void SetFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    public static float GetFloat(string key, float defaultValue = 0f)
    {
        return PlayerPrefs.GetFloat(key, defaultValue);
    }

    public static void SetString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }

    public static string GetString(string key, string defaultValue = "")
    {
        return PlayerPrefs.GetString(key, defaultValue);
    }

    public static void SetBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
    }

    public static bool GetBool(string key, bool defaultValue = false)
    {
        return PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) == 1;
    }


    // Save a generic object as JSON using Newtonsoft.Json, fallback to Unity's JsonUtility
    public static void SetJson<T>(string key, T value)      //Usage MyPlayerPrefs.SetJson("playerData", playerData);
    {
        try
        {
            string json = JsonConvert.SerializeObject(value);
            Debug.Log(json);
            PlayerPrefs.SetString(key, json);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to serialize object of type {typeof(T)} using JsonUtility: {ex.Message}");
        }
    }

    // Retrieve a generic object from JSON using Newtonsoft.Json, fallback to Unity's JsonUtility
    public static T GetJson<T>(string key, T defaultObject = default)     //Usage MyPlayerPrefs.GetJson<PlayerData>("playerData");
    {
        string json = PlayerPrefs.GetString(key, string.Empty);
        if (string.IsNullOrEmpty(json))
        {
            return (defaultObject);
        }

        try
        {
            Debug.Log(json);
            return JsonConvert.DeserializeObject<T>(json);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to deserialize JSON to object of type {typeof(T)} using JsonUtility: {ex.Message}");
            return default;
        }
    }


    public static void DeleteKey(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }

    public static void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }

    public static bool HasKey(string key)
    {
        return PlayerPrefs.HasKey(key);
    }
}
