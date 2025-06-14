using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class KeyValue<TKey, TValue>
{
    public TKey Key;
    public TValue Value;

    public KeyValue(TKey key, TValue value)
    {
        this.Key = key;
        this.Value = value;
    }
}


[Serializable]
public class SerializableDictionary<TKey, TValue>
{
    [SerializeField] private List<KeyValue<TKey, TValue>> keyValues = new();

    public void Add(TKey key, TValue value)
    {
        if (ContainsKey(key))
        {
            UpdateValue(key, value);
            return;
        }
        keyValues.Add(new KeyValue<TKey, TValue>(key, value));
    }

    public bool Remove(TKey key)
    {
        for (int i = 0; i < keyValues.Count; i++)
        {
            if (keyValues[i].Key.Equals(key))
            {
                keyValues.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    // Method to check if the dictionary contains a key
    public bool ContainsKey(TKey key)
    {
        return keyValues.Exists(kv => kv.Key.Equals(key));
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        foreach (var kvp in keyValues)
        {
            if (kvp.Key.Equals(key))
            {
                value = kvp.Value;
                return true;
            }
        }
        value = default(TValue);
        return false;
    }

    // Method to get the value by key
    public TValue GetValue(TKey key)
    {
        var keyValue = keyValues.Find(kv => kv.Key.Equals(key));
        if (keyValue != null)
        {
            return keyValue.Value;
        }
        MyAnalytics.RecordException($"The given key ({key}) was not present in the dictionary.");
        return default;
    }


    private void UpdateValue(TKey key, TValue value)
    {
        for (int i = 0; i < keyValues.Count; i++)
        {
            if (keyValues[i].Key.Equals(key))
            {
                keyValues[i].Value = value;
                return;
            }
        }
    }

    // Indexer to access values like a dictionary
    public TValue this[TKey key]
    {
        get
        {
            if (TryGetValue(key, out var value))
                return value;
            return default(TValue);
        }
        set
        {
            if (ContainsKey(key))
            {
                var keyValue = keyValues.Find(kv => kv.Key.Equals(key));
                keyValue.Value = value;
            }
            else
            {
                Add(key, value);
            }
        }
    }

    public Dictionary<TKey, TValue> ToDictionary()
    {
        Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
        foreach (var kvp in keyValues)
        {
            dictionary.Add(kvp.Key, kvp.Value);
        }
        return dictionary;
    }
}