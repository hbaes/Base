namespace Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using log4net;
    using log4net.Core;
    using log4net.Appender;
    using Base.Text;
    using System.Diagnostics;

    /// <summary>
    /// log4net Logging helpers
    /// </summary>
    public static partial class LogHelper
    {

        /// <summary>
        /// Converts LogLevels to log4net logLevel
        /// </summary>
        /// <param name="logLevel">The log level.</param>
        /// <returns></returns>
        public static log4net.Core.Level ConvertLogLevel(LogLevels logLevel)
        {
            log4net.Core.Level level = log4net.Core.Level.All;
            switch (logLevel)
            {
                case LogLevels.Debug:
                    level = log4net.Core.Level.Debug;
                    break;
                case LogLevels.Info:
                    level = log4net.Core.Level.Info;
                    break;
                case LogLevels.Warn:
                    level = log4net.Core.Level.Warn;
                    break;
                case LogLevels.Error:
                    level = log4net.Core.Level.Error;
                    break;
                case LogLevels.Fatal:
                    level = log4net.Core.Level.Fatal;
                    break;
            }
            return level;
        }

        /// <summary>
        /// Converts log4net loglevel to LogLevels
        /// </summary>
        /// <param name="log4netLevel">The log4net level.</param>
        /// <returns></returns>
        public static LogLevels ConvertLogLevel(log4net.Core.Level log4netLevel)
        {
            LogLevels level = LogLevels.Debug;
            if(log4netLevel==log4net.Core.Level.All)
            {
                    level = LogLevels.Debug;
            }
            if(log4netLevel== log4net.Core.Level.Debug)
            {
                    level = LogLevels.Debug;            
            }
            if (log4netLevel == log4net.Core.Level.Info)
            {
                level = LogLevels.Info;
            }
            if (log4netLevel == log4net.Core.Level.Warn)
            {
                level = LogLevels.Warn;
            }
            if (log4netLevel == log4net.Core.Level.Error)
            {
                level = LogLevels.Error;
            }
            if (log4netLevel == log4net.Core.Level.Fatal)
            {
                level = LogLevels.Fatal;
            }
            return level;
        }

        /// <summary>
        /// Sets the log threshold.
        /// </summary>
        /// <param name="level">The level.</param>
        public static void SetLogThreshold(LogLevels level)
        {
            SetLogThreshold(LogHelper.ConvertLogLevel(level));
        }

        /// <summary>
        /// Sets the log threshold.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <param name="except">do not modify this Appender.</param>
        public static void SetLogThreshold(LogLevels level, string[] except)
        {
            SetLogThreshold(LogHelper.ConvertLogLevel(level), except);
        }

        /// <summary>
        /// Sets the log threshold.
        /// </summary>
        /// <param name="level">The level.</param>
        public static void SetLogThreshold(log4net.Core.Level level)
        {
            foreach (AppenderSkeleton appender in LogManager.GetRepository().GetAppenders())
            {
                appender.Threshold = level;
                appender.ActivateOptions();
            }
        }

        /// <summary>
        /// Sets the log threshold.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <param name="except">do not modify this Appender.</param>
        public static void SetLogThreshold(log4net.Core.Level level, string[] except)
        {
            log.LogEnter();
            log.D("New threshold: {0}", level.DisplayName);
            log.D("Appender count in repository: {0}", LogManager.GetRepository().GetAppenders().Count());
            foreach (AppenderSkeleton appender in LogManager.GetRepository().GetAppenders())
            {
                log.D("- active Logger: '{0}'", appender.Name);
            }
            log.D("Loggers in Exception: {0}", except.Count());
            foreach (string exceptEntry in except)
            {
                log.D("- add Logger '{0}' to exception list (should not be changed)", exceptEntry); 
            }
            var appenders = from appender in LogManager.GetRepository().GetAppenders()
                            where !StringHelper.ArrayContainsString(except, appender.Name,true)
                            select appender;

            foreach (AppenderSkeleton appender in appenders)
            {
                log.D("change threshold for '{0}' to Level: {1}", appender.Name, level.DisplayName);
                Debug.Write(string.Format("change threshold for '{0}'", appender.Name));
                appender.Threshold = level;
                appender.ActivateOptions();
            }
            log.LogLeave();
        }

        /// <summary>
        /// Sets the root threshold.
        /// </summary>
        /// <param name="level">The level.</param>
        public static void SetRootThreshold(LogLevels level)
        {
            SetRootThreshold(LogHelper.ConvertLogLevel(level));
        }

        /// <summary>
        /// Sets the root threshold.
        /// </summary>
        /// <param name="level">The level.</param>
        public static void SetRootThreshold(log4net.Core.Level level)
        {
            log.LogEnter();
            log.D("set root loglevel threshold '{0}'", level.DisplayName);
            log4net.Repository.Hierarchy.Hierarchy repository =
                LogManager.GetRepository() as log4net.Repository.Hierarchy.Hierarchy;

            repository.Root.Level = level;
            repository.Configured = true;
            repository.RaiseConfigurationChanged(EventArgs.Empty);  
            log.LogLeave();
        }

        /// <summary>
        /// Adds the log appender.
        /// </summary>
        /// <param name="appender">The appender.</param>
        public static void AddLogAppender(IAppender appender)
        {
            log.LogEnter();
            log.D("Add appender '{0}'", appender.Name);
            log4net.Repository.Hierarchy.Hierarchy repository = 
                LogManager.GetRepository() as log4net.Repository.Hierarchy.Hierarchy;
            repository.Root.AddAppender(appender);

            repository.Configured = true;
            repository.RaiseConfigurationChanged(EventArgs.Empty); 
            log.LogLeave();
        }


    }
}
