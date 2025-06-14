using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants.AnalyticsEvents;

public class GameManagerInitializer : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.InitializeGameManager(); 
    }

    private void OnApplicationQuit()
    {
        MyAnalytics.LogEvent(Events.GAMECLOSE_EVENT);
    }
}
