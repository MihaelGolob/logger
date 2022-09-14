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
        
        public Unity3dEventSink(ITextFormatter formatter) => _formatter = formatter;
        
        /// <summary>
        /// write the log to Unity3D console with appropriate log level.
        /// </summary>
        /// <param name="logEvent"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Emit(LogEvent logEvent) {
            // destroy writer after use
            using var writer = new StringWriter();
            
            _formatter.Format(logEvent, writer);
            var message = writer.ToString().Trim();

            switch (logEvent.Level) {
                case LogEventLevel.Verbose:
                case LogEventLevel.Debug:
                case LogEventLevel.Information:
                    Debug.Log("<color=white>" + message + "</color>");
                    break;
                case LogEventLevel.Warning:
                    Debug.LogWarning("<color=orange>" + message + "</color>");
                    break;
                case LogEventLevel.Error:
                case LogEventLevel.Fatal:
                    Debug.LogError("<color=red><b>" + message + "</b></color>");
                    break;
                default: throw new ArgumentOutOfRangeException($"Log level {logEvent.Level} is not supported");
            }
        }
    }
}