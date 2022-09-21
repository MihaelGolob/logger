using System;
using UnityEngine;
using Ineor.Utils.Logger;

/// <summary>
/// A sample class to demonstrate how to use Ineor Log System (Attach this script to a GameObject in your scene)
/// </summary>
public class LogSample : MonoBehaviour {
    private void Start() {
        // Logger supports 3 levels of logging: Debug, Warning and Error.
        Log.Debug("Debug message");
        Log.Warning("Warning message");
        Log.Error("Error message");

        var x = "Hello World";
        var y = 10;
        var z = 250f;
        // no need to use string.Format() or string.Concat() to concatenate strings:
        // (also works with Warning and Error)
        // disclaimer: this works for up to 3 variables
        Log.Debug("x = {0}, y = {1}, z = {2}", x, y, z);
        // alternatively, you can use:
        Log.Debug($"x = {x}, y = {y}, z = {z}");
        
        Log.Warning($"All log files are stored in: {Application.persistentDataPath}");
        
        // Log system automatically logs exceptions too:
        throw new Exception("test exception");
    }

    private void Update() {
        
    }
}
