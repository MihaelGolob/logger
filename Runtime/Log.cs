using System;
using Serilog;
using Serilog.Sinks.File;
using Serilog.Sinks.Unity3D;

public class Log {
    // internal variables
    private static ILogger _logger;
    
    // public properties
    
    // ------------------------------ P U B L I C    A P I ------------------------------
    public static void Init(bool logToUnityConsole = true, bool logToFile = true) {
        // create logger configuration
        // enable debug messages with MinimumLevel
        var loggerConfiguration = new LoggerConfiguration().MinimumLevel.Verbose();
        
        // add sinks
        if (logToUnityConsole) {
            loggerConfiguration.WriteTo.Unity3D();
        }
        if (logToFile) {
            loggerConfiguration.WriteTo.File($"Log_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.txt");
        }
        
        // create logger
        _logger = loggerConfiguration.CreateLogger();
    }
    
    // Debug methods
    public static void Debug (string message) 
        => _logger.Debug(message);
    
    public static void Debug<T> (string message, T value) 
        => _logger.Debug(message, value);
    
    public static void Debug<T0, T1> (string message, T0 value0, T1 value1) 
        => _logger.Debug(message, value0, value1);
    
    public static void Debug<T0, T1, T2> (string message, T0 value0, T1 value1, T2 value2) 
        => _logger.Debug(message, value0, value1, value2);

    public static void Debug<T0, T1, T2, T3> (string message, T0 value0, T1 value1, T2 value2, T3 value3) 
        => _logger.Debug(message, value0, value1, value2, value3);
    
    public static void Debug<T0, T1, T2, T3, T4> (string message, T0 value0, T1 value1, T2 value2, T3 value3, T4 value4) 
        => _logger.Debug(message, value0, value1, value2, value3, value4);
    
    public static void Debug<T0, T1, T2, T3, T4, T5> (string message, T0 value0, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        => _logger.Debug(message, value0, value1, value2, value3, value4, value5);
    
    public static void Debug (Exception exception, string message) 
        => _logger.Debug(exception, message);
    
    public static void Debug<T> (Exception exception, string message, T value)
        => _logger.Debug(exception, message, value);
    
    public static void Debug<T0, T1> (Exception exception, string message, T0 value0, T1 value1)
        => _logger.Debug(exception, message, value0, value1);
    
    public static void Debug<T0, T1, T2> (Exception exception, string message, T0 value0, T1 value1, T2 value2)
        => _logger.Debug(exception, message, value0, value1, value2);
    
    public static void Debug<T0, T1, T2, T3> (Exception exception, string message, T0 value0, T1 value1, T2 value2, T3 value3)
        => _logger.Debug(exception, message, value0, value1, value2, value3);
    
    public static void Debug<T0, T1, T2, T3, T4> (Exception exception, string message, T0 value0, T1 value1, T2 value2, T3 value3, T4 value4)
        => _logger.Debug(exception, message, value0, value1, value2, value3, value4);
    
    public static void Debug<T0, T1, T2, T3, T4, T5> (Exception exception, string message, T0 value0, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        => _logger.Debug(exception, message, value0, value1, value2, value3, value4, value5);
    
    
    // Warning methods
    public static void Warning (string message) 
        => _logger.Warning(message);
    
    public static void Warning<T> (string message, T value) 
        => _logger.Warning(message, value);
    
    public static void Warning<T0, T1> (string message, T0 value0, T1 value1) 
        => _logger.Warning(message, value0, value1);
    
    public static void Warning<T0, T1, T2> (string message, T0 value0, T1 value1, T2 value2) 
        => _logger.Warning(message, value0, value1, value2);
    
    public static void Warning<T0, T1, T2, T3> (string message, T0 value0, T1 value1, T2 value2, T3 value3) 
        => _logger.Warning(message, value0, value1, value2, value3);
    
    public static void Warning<T0, T1, T2, T3, T4> (string message, T0 value0, T1 value1, T2 value2, T3 value3, T4 value4) 
        => _logger.Warning(message, value0, value1, value2, value3, value4);
    
    public static void Warning<T0, T1, T2, T3, T4, T5> (string message, T0 value0, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        => _logger.Warning(message, value0, value1, value2, value3, value4, value5);
    
    public static void Warning (Exception exception, string message) 
        => _logger.Warning(exception, message);
    
    public static void Warning<T> (Exception exception, string message, T value)
        => _logger.Warning(exception, message, value);
    
    public static void Warning<T0, T1> (Exception exception, string message, T0 value0, T1 value1)
        => _logger.Warning(exception, message, value0, value1);
    
    public static void Warning<T0, T1, T2> (Exception exception, string message, T0 value0, T1 value1, T2 value2)
        => _logger.Warning(exception, message, value0, value1, value2);
    
    public static void Warning<T0, T1, T2, T3> (Exception exception, string message, T0 value0, T1 value1, T2 value2, T3 value3)
        => _logger.Warning(exception, message, value0, value1, value2, value3);
    
    public static void Warning<T0, T1, T2, T3, T4> (Exception exception, string message, T0 value0, T1 value1, T2 value2, T3 value3, T4 value4)
        => _logger.Warning(exception, message, value0, value1, value2, value3, value4);
    
    public static void Warning<T0, T1, T2, T3, T4, T5> (Exception exception, string message, T0 value0, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        => _logger.Warning(exception, message, value0, value1, value2, value3, value4, value5);
    
    // Error methods 
    public static void Error (string message) 
        => _logger.Error(message);
    
    public static void Error<T> (string message, T value) 
        => _logger.Error(message, value);
    
    public static void Error<T0, T1> (string message, T0 value0, T1 value1) 
        => _logger.Error(message, value0, value1);
    
    public static void Error<T0, T1, T2> (string message, T0 value0, T1 value1, T2 value2) 
        => _logger.Error(message, value0, value1, value2);
    
    public static void Error<T0, T1, T2, T3> (string message, T0 value0, T1 value1, T2 value2, T3 value3) 
        => _logger.Error(message, value0, value1, value2, value3);
    
    public static void Error<T0, T1, T2, T3, T4> (string message, T0 value0, T1 value1, T2 value2, T3 value3, T4 value4) 
        => _logger.Error(message, value0, value1, value2, value3, value4);
    
    public static void Error<T0, T1, T2, T3, T4, T5> (string message, T0 value0, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        => _logger.Error(message, value0, value1, value2, value3, value4, value5);
    
    public static void Error (Exception exception, string message) 
        => _logger.Error(exception, message);
    
    public static void Error<T> (Exception exception, string message, T value)
        => _logger.Error(exception, message, value);
    
    public static void Error<T0, T1> (Exception exception, string message, T0 value0, T1 value1)
        => _logger.Error(exception, message, value0, value1);
    
    public static void Error<T0, T1, T2> (Exception exception, string message, T0 value0, T1 value1, T2 value2)
        => _logger.Error(exception, message, value0, value1, value2);
    
    public static void Error<T0, T1, T2, T3> (Exception exception, string message, T0 value0, T1 value1, T2 value2, T3 value3)
        => _logger.Error(exception, message, value0, value1, value2, value3);
    
    public static void Error<T0, T1, T2, T3, T4> (Exception exception, string message, T0 value0, T1 value1, T2 value2, T3 value3, T4 value4)
        => _logger.Error(exception, message, value0, value1, value2, value3, value4);
    
    public static void Error<T0, T1, T2, T3, T4, T5> (Exception exception, string message, T0 value0, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        => _logger.Error(exception, message, value0, value1, value2, value3, value4, value5);
    
}