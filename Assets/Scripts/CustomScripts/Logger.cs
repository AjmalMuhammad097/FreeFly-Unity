using UnityEngine;

public static class Logger
{
    public static bool IsDebugBuild => Debug.isDebugBuild;

    public static string Log(object log)
    {
        return Log(LogType.Log, log);
    }

    public static string LogWarning(object log)
    {
        return Log(LogType.Warning, log);
    }

    public static string LogError(object log)
    {
        if (IsDebugBuild)
            Log(LogType.Error, log);
        return log.ToString();
    }

    public static string LogCriticalError(object log)
    {
        return Log(LogType.Error, log);
    }

    private static string Log(LogType logType, object log)
    {
        object formattedString;
        try
        {
            var stackTrace = new System.Diagnostics.StackTrace(true);
            var stackFrame = stackTrace.GetFrame(2); // Skip the current and next frame
            var method = stackFrame?.GetMethod();
            var lineNumber = stackFrame?.GetFileLineNumber();
            var fileName = stackFrame?.GetFileName();

            string methodName = method?.Name ?? "UnknownMethod";
            string file = fileName ?? "UnknownFile";
            int line = lineNumber ?? 0;

            formattedString = $"{log}\n{methodName} in {file}:{line}";
        }
        catch (System.Exception ex)
        {
            formattedString = log;
            LogError(ex);
        }

        if (IsDebugBuild || logType == LogType.Error)
            LogMessage(logType, formattedString);

        return formattedString.ToString();
    }

    private static void LogMessage(LogType logType, object log)
    {
        switch (logType)
        {
            case LogType.Exception:
                var ex = new System.Exception(log.ToString());
                Debug.LogException(ex);
                break;

            case LogType.Error:
                Debug.LogError(log);
                break;

            case LogType.Warning:
                Debug.LogWarning(log);
                break;

            case LogType.Log:
            default:
                Debug.Log(log);
                break;
        }
    }
}


