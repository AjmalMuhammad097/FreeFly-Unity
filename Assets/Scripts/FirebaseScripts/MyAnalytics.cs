using System;
#if !UNITY_WEBGL
using Firebase.Analytics;
using Firebase.Crashlytics;
#endif

public static class MyAnalytics
{
    public static void LogEvent(string eventName)  //For just events
    {
        try
        {
#if !UNITY_WEBGL
            FirebaseAnalytics.LogEvent(Logger.Log($"{eventName}"));
#endif
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
#if !UNITY_WEBGL
            FirebaseAnalytics.LogEvent($"{eventName}", new Parameter[]
            {
                new(parameterName, parameterValue)
            });
#endif
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
#if !UNITY_WEBGL
            FirebaseAnalytics.LogEvent(Logger.Log($"{eventName}"));
#endif
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
#if !UNITY_WEBGL
            Logger.LogCriticalError(e);
            Crashlytics.LogException(e);
#endif
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
