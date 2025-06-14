using UnityEngine;
using static Constants.AnalyticsEvents;

public class GameController : MonoBehaviour
{
    public void Start()
    {
        GameManager.Instance.StartGame();
        Debug.Log("Starting the Game...");
    }

    private void OnApplicationQuit()
    {
        MyAnalytics.LogEvent(Events.GAMECLOSE_EVENT);
    }
}
