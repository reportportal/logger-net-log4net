using System.Collections.Generic;
using ReportPortal.Shared;
using log4net.Appender;
using log4net.Core;
using ReportPortal.Shared.Execution.Logging;

namespace ReportPortal.Log4Net
{
    /// <summary>
    /// Log4Net custom adapter for reporting logs directly to Report Portal.
    /// Logs will be viewable under current test item from shared context.
    /// </summary>
    public class ReportPortalAppender : AppenderSkeleton
    {
        protected Dictionary<Level, LogMessageLevel> LevelMap = new Dictionary<Level, LogMessageLevel>();
        public ReportPortalAppender()
        {
            LevelMap[Level.Fatal] = LogMessageLevel.Fatal;
            LevelMap[Level.Error] = LogMessageLevel.Error;
            LevelMap[Level.Warn] = LogMessageLevel.Warning;
            LevelMap[Level.Info] = LogMessageLevel.Info;
            LevelMap[Level.Debug] = LogMessageLevel.Debug;
            LevelMap[Level.Trace] = LogMessageLevel.Trace;
        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            var level = LogMessageLevel.Info;
            if (LevelMap.ContainsKey(loggingEvent.Level))
            {
                level = LevelMap[loggingEvent.Level];
            }

            var logMessage = new LogMessage(RenderLoggingEvent(loggingEvent));
            logMessage.Time = loggingEvent.TimeStampUtc;
            logMessage.Level = level;

            Context.Current.Log.Message(logMessage);
        }
    }
}
