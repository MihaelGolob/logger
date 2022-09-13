using UnityEngine;
using Serilog;
using Serilog.Sinks.Unity3D;
using Serilog.Sinks.File;

public class SerilogTest : MonoBehaviour {
        
    private void Start() {
        Serilog.ILogger logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Unity3D()
            .WriteTo.File("log.txt")
            .CreateLogger();
        
        logger.Information("Information message");
        logger.Debug("Debug message");
        logger.Warning("warning");
        logger.Error("this is an error");
    }
}   