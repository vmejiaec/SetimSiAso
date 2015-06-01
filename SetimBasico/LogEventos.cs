using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetNuke.Services.Log.EventLog;

namespace SetimBasico
{
    public class LogEventos
    {
        // Manejo de los eventos

        private readonly EventLogController _eventLogController = new EventLogController();

        public void AddLog(string key, string friendlyName, Entidad entidad)
        {
            EnsureLogTypeExists(key, friendlyName);

            var log = new LogInfo { LogTypeKey = key };
            log.LogProperties.Add(new LogDetailInfo("EntidadId", entidad.Id.ToString()));
            //log.LogProperties.Add(new LogDetailInfo("TaskName", task.Name));
            //log.LogProperties.Add(new LogDetailInfo("TaskDescription", task.Description));

            _eventLogController.AddLog(log);
        }

        private void EnsureLogTypeExists(string key, string friendlyName)
        {
            LogTypeInfo logType = null;
            var logTypeDictionary = _eventLogController.GetLogTypeInfoDictionary();
            if (!logTypeDictionary.TryGetValue(key, out logType))
            {
                // Add new logType
                logType = new LogTypeInfo()
                {
                    LogTypeKey = key,
                    LogTypeFriendlyName = friendlyName,
                    LogTypeDescription = string.Empty,
                    LogTypeCSSClass = "OperationSucces",
                    LogTypeOwner = "DotNetNuke.Logging.EventLogType"
                };
                _eventLogController.AddLogType(logType);

                var logTypeConfig = new LogTypeConfigInfo()
                {
                    LoggingIsActive = true,
                    LogTypeKey = key,
                    KeepMostRecent = "100",
                    NotificationThreshold = 1,
                    NotificationThresholdTime = 1,
                    NotificationThresholdTimeType = LogTypeConfigInfo.NotificationThresholdTimeTypes.Seconds,
                    MailFromAddress = string.Empty,
                    MailToAddress = string.Empty,
                    LogTypePortalID = "*"
                };
                _eventLogController.AddLogTypeConfigInfo(logTypeConfig);
            }
        }
    }
}
