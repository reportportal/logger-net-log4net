using System.Collections.Generic;
using ReportPortal.Shared;
using log4net.Appender;
using log4net.Core;
using ReportPortal.Client.Abstractions.Responses;
using ReportPortal.Client.Abstractions.Requests;

namespace ReportPortal.Log4Net
{
    /// <summary>
    /// Log4Net custom adapter for reporting logs directly to Report Portal.
    /// Logs will be viewable under current test item from shared context.
    /// </summary>
    public class ReportPortalAppender : AppenderSkeleton
    {
        protected Dictionary<Level, LogLevel> LevelMap = new Dictionary<Level, LogLevel>();
        public ReportPortalAppender()
        {
            LevelMap[Level.Fatal] = LogLevel.Fatal;
            LevelMap[Level.Error] = LogLevel.Error;
            LevelMap[Level.Warn] = LogLevel.Warning;
            LevelMap[Level.Info] = LogLevel.Info;
            LevelMap[Level.Debug] = LogLevel.Debug;
            LevelMap[Level.Trace] = LogLevel.Trace;
        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            var level = LogLevel.Info;
            if (LevelMap.ContainsKey(loggingEvent.Level))
            {
                level = LevelMap[loggingEvent.Level];
            }

            Log.Message(new CreateLogItemRequest
            {
                Level = level,
                Time = loggingEvent.TimeStampUtc,
                Text = RenderLoggingEvent(loggingEvent)
            });
        }
    }
}
