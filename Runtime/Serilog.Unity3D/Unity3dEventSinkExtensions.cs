using System;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Display;

namespace Serilog.Sinks.Unity3D {
    /// <summary>
    /// provides extension methods for LoggerConfiguration for creating a logger.
    /// </summary>
    public static class Unity3dEventSinkExtensions {
        private const string DefaultOutputFormat = "[{Level:u3}] {Message:lj}{NewLine}{Exception}";

        /// <summary>
        /// return the unity sink logger configuration
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="level"></param>
        /// <param name="outputTemplate"></param>
        /// <param name="formatProvider"></param>
        /// <param name="levelSwitch"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static LoggerConfiguration Unity3D(this LoggerSinkConfiguration configuration, LogEventLevel level = LevelAlias.Minimum, string outputTemplate = DefaultOutputFormat, IFormatProvider formatProvider = null, LoggingLevelSwitch levelSwitch = null) {
            if (configuration == null)
                throw new ArgumentException(nameof(configuration));
            if (outputTemplate == null)
                throw new ArgumentException(nameof(outputTemplate));

            var formatter = new MessageTemplateTextFormatter(outputTemplate, formatProvider);
            return configuration.Unity3D(formatter, level, levelSwitch);
        }
        
        /// <summary>
        /// return the unity sink logger configuration.
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="formatter"></param>
        /// <param name="level"></param>
        /// <param name="levelSwitch"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static LoggerConfiguration Unity3D(this LoggerSinkConfiguration configuration, ITextFormatter formatter, LogEventLevel level = LevelAlias.Minimum, LoggingLevelSwitch levelSwitch = null) {
            if (configuration == null)
                throw new ArgumentException(nameof(configuration));
            if (formatter == null)
                throw new ArgumentException(nameof(formatter));

            return configuration.Sink(new Unity3dEventSink(formatter), level, levelSwitch);
        }
    }
}