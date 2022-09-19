using System;
using System.IO;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using UnityEngine;

namespace Serilog.Sinks.Unity3D {
    /// <summary>
    /// This class is used to provide a link between Serilog and Unity3D console output.
    /// </summary>
    public sealed class Unity3dEventSink : ILogEventSink {
        private readonly ITextFormatter _formatter;

        // constructor
        public Unity3dEventSink(ITextFormatter formatter) => _formatter = formatter;

        /// <summary>
        /// write the log to Unity3D console with appropriate log level.
        /// </summary>
        /// <param name="logEvent"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Emit(LogEvent logEvent) {
            // destroy writer after use
            // this is to insure that the method is thread safe
            using var writer = new StringWriter();
            _formatter.Format(logEvent, writer);
            
            switch (logEvent.Level) {
                case LogEventLevel.Verbose:
                case LogEventLevel.Debug:
                case LogEventLevel.Information:
                    Debug.Log("<color=white>" + writer + "</color>");
                    break;
                case LogEventLevel.Warning:
                    Debug.LogWarning("<color=orange>" + writer + "</color>");
                    break;
                case LogEventLevel.Error:
                case LogEventLevel.Fatal:
                    Debug.LogError("<color=red><b>" + writer + "</b></color>");
                    break;
                default: throw new ArgumentOutOfRangeException($"Log level {logEvent.Level} is not supported");
            }
        }
    }
}