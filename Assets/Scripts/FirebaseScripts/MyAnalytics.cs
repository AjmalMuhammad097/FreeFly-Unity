using System;
using Firebase.Analytics;
using Firebase.Crashlytics;

public static class MyAnalytics
{
    public static void LogEvent(string eventName)  //For just events
    {
        try
        {
            FirebaseAnalytics.LogEvent(Logger.Log($"{eventName}"));
        }
        catch (Exception e)
        {
            RecordException($"Event cannot be Logged with exception: {e}");
        }
    }

    public static void LogEvent(string eventName, string parameterName, string parameterValue) //For events with parameters
    {
        Logger.Log($"{eventName} :: {parameterName} : {parameterValue}");
        try
        {
            FirebaseAnalytics.LogEvent($"{eventName}", new Parameter[]
            {
                new(parameterName, parameterValue)
            });
        }
        catch (Exception e)
        {
            RecordException($"Event cannot be Logged with exception: {e}");
        }
    }

    public static void LogButtonEvent(string eventName)    //For Buttons
    {
        try
        {
            FirebaseAnalytics.LogEvent(Logger.Log($"{eventName}"));
        }
        catch (Exception e)
        {
            RecordException($"Event cannot be Logged with exception: {e}");
        }
    }

    public static void RecordException(Exception e)
    {
        try
        {
            Logger.LogCriticalError(e);
            Crashlytics.LogException(e);
        }
        catch (Exception ex)
        {
            Logger.LogCriticalError($"Failed to record exception: {e}");
            Logger.LogError(ex);
        }
    }

    public static void RecordException(string e)
    {
        var exception = new Exception(e);
        RecordException(exception);
    }
}
