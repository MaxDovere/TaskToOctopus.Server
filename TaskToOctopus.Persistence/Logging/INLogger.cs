using System;

namespace TaskToOctopus.Persistence.Logging
{
    public interface INLogger<T> where T: class
    {
        void LogInformation(string message);
        void LogFatal(string message);
        void LogFatal(Exception ex, string message);
        void LogDebug(string message);
        void LogDebug(Exception ex, string message);
        void LogError(string message);
        void LogError(Exception ex, string message);
        void LogWarning(string message);
        void LogWarning(Exception ex, string message);

    }
}
