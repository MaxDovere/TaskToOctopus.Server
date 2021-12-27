using NLog;
using NLog.Web;
using System;

namespace TaskToOctopus.Persistence.Logging
{
    public class NLogger<T> : INLogger<T> where T : class
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly object _class;
        private string _fullname { get; set; }
        private string _name { get; set;}
        public NLogger()
                :base()
        {
            _logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            
            _class = typeof(T);
            _name = _class.ToString();
            _fullname = _class.GetType().FullName;

        }

        public void LogDebug(Exception ex, string message)
        {
            this._logger.Debug(ex, $"{_fullname}[{_name}]:{message}");
        }

        public void LogDebug(string message)
        {
            this._logger.Debug($"{_fullname}[{_name}]:{message}");
        }

        public void LogError(string message)
        {
            this._logger.Error($"{_fullname}[{_name}]:{message}");
        }

        public void LogError(Exception ex, string message)
        {
            this._logger.Error(ex, $"{_fullname}[{_name}]:{message}");
        }

        public void LogFatal(Exception ex, string message)
        {
            this._logger.Fatal(ex, $"{_fullname}[{_name}]:{message}");
        }

        public void LogFatal(string message)
        {
            this._logger.Fatal($"{_fullname}[{_name}]:{message}");
        }

        public void LogInformation(string message)
        {
            this._logger.Info($"{_fullname}[{_name}]:{message}");
        }

        public void LogWarning(string message)
        {
            this._logger.Warn($"{_fullname}[{_name}]:{message}");
        }

        public void LogWarning(Exception ex, string message)
        {
            this._logger.Warn(ex, $"{_fullname}[{_name}]:{message}");
        }
    }
}
