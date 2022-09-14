using System;
using Serilog;
using Serilog.Sinks.Unity3D;

#if UNITY_EDITOR 
using UnityEngine;
#endif

/// <summary>
/// A static class that provides the interface for logging. Must call Log.Initialize() before using. 
/// </summary>
public static class Log {
    // internal variables
    private static Serilog.ILogger _logger;
    
    // public properties
    
    // static constructor
    static Log() {
        // subscribe to events
        Application.logMessageReceivedThreaded += LogException;
    }
    
    // ------------------------------ P R I V A T E -------------------------------------
    // This callback is called when an exception is thrown in any thread (including the main thread)
    private static void LogException(string log, string stackTrace, LogType type) {
        if (type != LogType.Exception) return;
        // log the error so we can see it in the file afterwards
        _logger.Error(log + "\n" + stackTrace);
    }
    
    // ------------------------------ P U B L I C    A P I ------------------------------
    /// <summary>
    /// Initialize the Logger and specify the outputs
    /// </summary>
    /// <param name="logToUnityConsole"></param>
    /// <param name="logToFile"></param>
    /// <param name="fileName"></param>
    public static void Init(bool logToUnityConsole = true, bool logToFile = true, string fileName = null) {
        // create logger configuration
        // enable debug messages with MinimumLevel
        var loggerConfiguration = new LoggerConfiguration().MinimumLevel.Verbose();
        
        // add sinks depending on the parameters
        if (logToUnityConsole) {
            loggerConfiguration.WriteTo.Unity3D();
        }
        if (logToFile) {
            if (fileName == null)
                loggerConfiguration.WriteTo.File($"Log_{DateTime.Now.ToString("dd.MM.yyyy_HH-mm-ss")}.txt");
            else
                loggerConfiguration.WriteTo.File(fileName);
        }
        
        // create logger
        _logger = loggerConfiguration.CreateLogger();
    }
    
    // Debug methods
    /// <summary>
    /// Log a debug message
    /// </summary>
    /// <param name="message"></param>
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Debug (string message) 
        => _logger.Debug(message);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Debug<T> (string message, T value) 
        => _logger.Debug(message, value);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Debug<T0, T1> (string message, T0 value0, T1 value1) 
        => _logger.Debug(message, value0, value1);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Debug<T0, T1, T2> (string message, T0 value0, T1 value1, T2 value2) 
        => _logger.Debug(message, value0, value1, value2);

    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Debug<T0, T1, T2, T3> (string message, T0 value0, T1 value1, T2 value2, T3 value3) 
        => _logger.Debug(message, value0, value1, value2, value3);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Debug<T0, T1, T2, T3, T4> (string message, T0 value0, T1 value1, T2 value2, T3 value3, T4 value4) 
        => _logger.Debug(message, value0, value1, value2, value3, value4);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Debug<T0, T1, T2, T3, T4, T5> (string message, T0 value0, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        => _logger.Debug(message, value0, value1, value2, value3, value4, value5);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Debug (Exception exception, string message) 
        => _logger.Debug(exception, message);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Debug<T> (Exception exception, string message, T value)
        => _logger.Debug(exception, message, value);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Debug<T0, T1> (Exception exception, string message, T0 value0, T1 value1)
        => _logger.Debug(exception, message, value0, value1);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Debug<T0, T1, T2> (Exception exception, string message, T0 value0, T1 value1, T2 value2)
        => _logger.Debug(exception, message, value0, value1, value2);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Debug<T0, T1, T2, T3> (Exception exception, string message, T0 value0, T1 value1, T2 value2, T3 value3)
        => _logger.Debug(exception, message, value0, value1, value2, value3);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Debug<T0, T1, T2, T3, T4> (Exception exception, string message, T0 value0, T1 value1, T2 value2, T3 value3, T4 value4)
        => _logger.Debug(exception, message, value0, value1, value2, value3, value4);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Debug<T0, T1, T2, T3, T4, T5> (Exception exception, string message, T0 value0, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        => _logger.Debug(exception, message, value0, value1, value2, value3, value4, value5);
    
    
    // Warning methods
    /// <summary>
    /// Log a warning message.
    /// </summary>
    /// <param name="message"></param>
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Warning (string message) 
        => _logger.Warning(message);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Warning<T> (string message, T value) 
        => _logger.Warning(message, value);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Warning<T0, T1> (string message, T0 value0, T1 value1) 
        => _logger.Warning(message, value0, value1);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Warning<T0, T1, T2> (string message, T0 value0, T1 value1, T2 value2) 
        => _logger.Warning(message, value0, value1, value2);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Warning<T0, T1, T2, T3> (string message, T0 value0, T1 value1, T2 value2, T3 value3) 
        => _logger.Warning(message, value0, value1, value2, value3);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Warning<T0, T1, T2, T3, T4> (string message, T0 value0, T1 value1, T2 value2, T3 value3, T4 value4) 
        => _logger.Warning(message, value0, value1, value2, value3, value4);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Warning<T0, T1, T2, T3, T4, T5> (string message, T0 value0, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        => _logger.Warning(message, value0, value1, value2, value3, value4, value5);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Warning (Exception exception, string message) 
        => _logger.Warning(exception, message);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Warning<T> (Exception exception, string message, T value)
        => _logger.Warning(exception, message, value);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Warning<T0, T1> (Exception exception, string message, T0 value0, T1 value1)
        => _logger.Warning(exception, message, value0, value1);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Warning<T0, T1, T2> (Exception exception, string message, T0 value0, T1 value1, T2 value2)
        => _logger.Warning(exception, message, value0, value1, value2);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Warning<T0, T1, T2, T3> (Exception exception, string message, T0 value0, T1 value1, T2 value2, T3 value3)
        => _logger.Warning(exception, message, value0, value1, value2, value3);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Warning<T0, T1, T2, T3, T4> (Exception exception, string message, T0 value0, T1 value1, T2 value2, T3 value3, T4 value4)
        => _logger.Warning(exception, message, value0, value1, value2, value3, value4);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Warning<T0, T1, T2, T3, T4, T5> (Exception exception, string message, T0 value0, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        => _logger.Warning(exception, message, value0, value1, value2, value3, value4, value5);
    
    // Error methods 
    /// <summary>
    /// Log an error message.
    /// </summary>
    /// <param name="message"></param>
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Error (string message) 
        => _logger.Error(message);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Error<T> (string message, T value) 
        => _logger.Error(message, value);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Error<T0, T1> (string message, T0 value0, T1 value1) 
        => _logger.Error(message, value0, value1);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Error<T0, T1, T2> (string message, T0 value0, T1 value1, T2 value2) 
        => _logger.Error(message, value0, value1, value2);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Error<T0, T1, T2, T3> (string message, T0 value0, T1 value1, T2 value2, T3 value3) 
        => _logger.Error(message, value0, value1, value2, value3);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Error<T0, T1, T2, T3, T4> (string message, T0 value0, T1 value1, T2 value2, T3 value3, T4 value4) 
        => _logger.Error(message, value0, value1, value2, value3, value4);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Error<T0, T1, T2, T3, T4, T5> (string message, T0 value0, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        => _logger.Error(message, value0, value1, value2, value3, value4, value5);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Error (Exception exception, string message) 
        => _logger.Error(exception, message);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Error<T> (Exception exception, string message, T value)
        => _logger.Error(exception, message, value);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Error<T0, T1> (Exception exception, string message, T0 value0, T1 value1)
        => _logger.Error(exception, message, value0, value1);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Error<T0, T1, T2> (Exception exception, string message, T0 value0, T1 value1, T2 value2)
        => _logger.Error(exception, message, value0, value1, value2);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Error<T0, T1, T2, T3> (Exception exception, string message, T0 value0, T1 value1, T2 value2, T3 value3)
        => _logger.Error(exception, message, value0, value1, value2, value3);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Error<T0, T1, T2, T3, T4> (Exception exception, string message, T0 value0, T1 value1, T2 value2, T3 value3, T4 value4)
        => _logger.Error(exception, message, value0, value1, value2, value3, value4);
    
    [System.Diagnostics.Conditional("ENABLE_LOGS")]
    public static void Error<T0, T1, T2, T3, T4, T5> (Exception exception, string message, T0 value0, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        => _logger.Error(exception, message, value0, value1, value2, value3, value4, value5);
    
}