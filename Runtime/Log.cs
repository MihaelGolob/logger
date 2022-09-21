using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Serilog;
using Serilog.Core;
using Serilog.Unity3D;
using UnityEngine;

namespace Ineor.Utils.Logger {
    /// <summary>
    /// A static class that provides the interface for logging. 
    /// </summary>
    public static class Log {
        // internal variables
        private static Serilog.ILogger _logger;

        private enum LogLevel { Debug, Warning, Error }

        // public properties
        public static bool LogExceptions { get; set; } = true;

        // static constructor
        static Log() {
            // subscribe to events
            Application.logMessageReceivedThreaded += LogException;

            // initialize logger
            Init();
        }

        // ------------------------------ P R I V A T E -------------------------------------
        // This callback is called when an exception is thrown in any thread (including the main thread)
        private static void LogException(string log, string stackTrace, LogType type) {
            if (type != LogType.Exception || !LogExceptions) return;
            // log the error so we can see it in the file afterwards
            // TODO: log exceptions to file only
            _logger.Fatal(log + "\n" + stackTrace);
        }

        /// <summary>
        /// Initialize the Logger and specify the outputs
        /// </summary>
        private static void Init() {
            const string unityTemplate = "[frame:{frameCount}  {callerTypeName}:{callerMemberName} ({callerLineNumber})]  {Message:lj}";
            const string fileTemplate = "[{Level:u3}:{Timestamp:HH:mm:ss}] [frame:{frameCount}  {callerTypeName}:{callerMemberName} ({callerLineNumber})]  {Message:lj} {NewLine}";
            var fileName = $"/{DateTime.Now:dd.MM.yyyy}_{DateTime.Now:HH.mm.ss}.log";

            // create logger configuration
            // enable debug messages with MinimumLevel
            var loggerConfiguration = new LoggerConfiguration().MinimumLevel.Verbose()
                .WriteTo.Unity3D(unityTemplate)
                .WriteTo.File(Application.persistentDataPath + fileName, outputTemplate: fileTemplate);

            // create logger
            _logger = loggerConfiguration.CreateLogger();
        }

        /// <summary>
        /// A write method that calls the Serilog's logging methods
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level"></param>
        /// <param name="callerMemberName"></param>
        /// <param name="callerLineNumber"></param>
        private static void Write(string message, LogLevel level, string callerMemberName, int callerLineNumber) {
            // get type name with reflection (have to skip 2 frames)
            var frame = new StackFrame(2);
            var typeName = frame.GetMethod().DeclaringType;

            // call the appropriate logging method and supply the necessary context
            // needed for the output template.
            switch (level) {
                case LogLevel.Debug:
                    _logger
                        .ForContext("frameCount", Time.frameCount)
                        .ForContext("callerMemberName", callerMemberName)
                        .ForContext("callerLineNumber", callerLineNumber)
                        .ForContext("callerTypeName", typeName)
                        .Debug(message);
                    break;
                case LogLevel.Warning:
                    _logger
                        .ForContext("frameCount", Time.frameCount)
                        .ForContext("callerMemberName", callerMemberName)
                        .ForContext("callerLineNumber", callerLineNumber)
                        .ForContext("callerTypeName", typeName)
                        .Warning(message);
                    break;
                case LogLevel.Error:
                    _logger
                        .ForContext("frameCount", Time.frameCount)
                        .ForContext("callerMemberName", callerMemberName)
                        .ForContext("callerLineNumber", callerLineNumber)
                        .ForContext("callerTypeName", typeName)
                        .Error(message);
                    break;
            }
        }

        // ------------------------------ P U B L I C    A P I ------------------------------
        // Debug methods
        /// <summary>
        /// Log a debug message. Uses CallerMemberName attributes for the caller's name and line number.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="callerMemberName"></param>
        /// <param name="callerLineNumber"></param>
        [Conditional("ENABLE_LOGS")]
        [MessageTemplateFormatMethod("message")]
        public static void Debug(string message, [CallerMemberName] string callerMemberName = null, [CallerLineNumber] int callerLineNumber = 0)
            => Write(message, LogLevel.Debug, callerMemberName, callerLineNumber);


        [Conditional("ENABLE_LOGS")]
        [MessageTemplateFormatMethod("message")]
        public static void Debug<T>(string message, T value, [CallerMemberName] string callerMemberName = null, [CallerLineNumber] int callerLineNumber = 0)
            => Write(string.Format(message, value), LogLevel.Debug, callerMemberName, callerLineNumber);

        [Conditional("ENABLE_LOGS")]
        [MessageTemplateFormatMethod("messageTemplate")]
        public static void Debug<T0, T1>(string message, T0 value0, T1 value1, [CallerMemberName] string callerMemberName = null, [CallerLineNumber] int callerLineNumber = 0)
            => Write(string.Format(message, value0, value1), LogLevel.Debug, callerMemberName, callerLineNumber);

        [Conditional("ENABLE_LOGS")]
        [MessageTemplateFormatMethod("message")]
        public static void Debug<T0, T1, T2>(string message, T0 value0, T1 value1, T2 value2, [CallerMemberName] string callerMemberName = null, [CallerLineNumber] int callerLineNumber = 0)
            => Write(string.Format(message, value0, value1, value2), LogLevel.Debug, callerMemberName, callerLineNumber);

        // Warning methods
        /// <summary>
        /// Log a warning message.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="callerMemberName"></param>
        /// <param name="callerLineNumber"></param>
        [Conditional("ENABLE_LOGS")]
        [MessageTemplateFormatMethod("message")]
        public static void Warning(string message, [CallerMemberName] string callerMemberName = null, [CallerLineNumber] int callerLineNumber = 0)
            => Write(message, LogLevel.Warning, callerMemberName, callerLineNumber);

        [Conditional("ENABLE_LOGS")]
        [MessageTemplateFormatMethod("message")]
        public static void Warning<T>(string message, T value, [CallerMemberName] string callerMemberName = null, [CallerLineNumber] int callerLineNumber = 0)
            => Write(string.Format(message, value), LogLevel.Warning, callerMemberName, callerLineNumber);

        [Conditional("ENABLE_LOGS")]
        [MessageTemplateFormatMethod("message")]
        public static void Warning<T0, T1>(string message, T0 value0, T1 value1, [CallerMemberName] string callerMemberName = null, [CallerLineNumber] int callerLineNumber = 0)
            => Write(string.Format(message, value0, value1), LogLevel.Warning, callerMemberName, callerLineNumber);

        [Conditional("ENABLE_LOGS")]
        [MessageTemplateFormatMethod("message")]
        public static void Warning<T0, T1, T2>(string message, T0 value0, T1 value1, T2 value2, [CallerMemberName] string callerMemberName = null, [CallerLineNumber] int callerLineNumber = 0)
            => Write(string.Format(message, value0, value1, value2), LogLevel.Warning, callerMemberName, callerLineNumber);

        // Error methods 
        /// <summary>
        /// Log an error message.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="callerMemberName"></param>
        /// <param name="callerLineNumber"></param>
        [Conditional("ENABLE_LOGS")]
        [MessageTemplateFormatMethod("message")]
        public static void Error(string message, [CallerMemberName] string callerMemberName = null, [CallerLineNumber] int callerLineNumber = 0)
            => Write(message, LogLevel.Error, callerMemberName, callerLineNumber);

        [Conditional("ENABLE_LOGS")]
        [MessageTemplateFormatMethod("message")]
        public static void Error<T>(string message, T value, [CallerMemberName] string callerMemberName = null, [CallerLineNumber] int callerLineNumber = 0)
            => Write(string.Format(message, value), LogLevel.Error, callerMemberName, callerLineNumber);

        [Conditional("ENABLE_LOGS")]
        [MessageTemplateFormatMethod("message")]
        public static void Error<T0, T1>(string message, T0 value0, T1 value1, [CallerMemberName] string callerMemberName = null, [CallerLineNumber] int callerLineNumber = 0)
            => Write(string.Format(message, value0, value1), LogLevel.Error, callerMemberName, callerLineNumber);

        [Conditional("ENABLE_LOGS")]
        [MessageTemplateFormatMethod("message")]
        public static void Error<T0, T1, T2>(string message, T0 value0, T1 value1, T2 value2, [CallerMemberName] string callerMemberName = null, [CallerLineNumber] int callerLineNumber = 0)
            => Write(string.Format(message, value0, value1, value2), LogLevel.Error, callerMemberName, callerLineNumber);

    }
}