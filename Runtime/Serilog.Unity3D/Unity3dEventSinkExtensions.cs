using System;
using Serilog.Configuration;
using Serilog.Formatting;
using Serilog.Formatting.Display;

namespace Serilog.Unity3D {
    /// <summary>
    /// provides extension methods for LoggerConfiguration for creating a logger.
    /// </summary>
    public static class Unity3dEventSinkExtensions {
        /// <summary>
        /// return the unity sink logger configuration
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="outputTemplate"></param> 
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static LoggerConfiguration Unity3D(this LoggerSinkConfiguration configuration, string outputTemplate) {
            if (configuration == null)
                throw new ArgumentException(nameof(configuration));
            
            var formatter = new MessageTemplateTextFormatter(outputTemplate);
            return configuration.Unity3D(formatter);
        }
        
        /// <summary>
        /// return the unity sink logger configuration.
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="formatter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private static LoggerConfiguration Unity3D(this LoggerSinkConfiguration configuration, ITextFormatter formatter) {
            if (configuration == null)
                throw new ArgumentException(nameof(configuration));
            if (formatter == null)
                throw new ArgumentException(nameof(formatter));

            return configuration.Sink(new Unity3dEventSink(formatter), levelSwitch: null);
        }
    }
}