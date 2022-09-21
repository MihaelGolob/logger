# Ineor Log System package

This is a Log system package based on the Serilog library. It currently supports logging to 
the Unity Console and to a file on the system. It can automatically log exceptions/crashes to
a file before the application crashes.

## How to use
1. Add the package to your project
2. To enable logs you need to globally define the `ENABLE_LOGS` symbol. To do this, go to: `Unity->Edit->Project Settings->Player->Other Settings->Scripting Define Symbols` and add the symbol.
3. Add `using Ineor.Utils.Logger` to your scripts.
4. Start logging messages.

*Created by Mihael Golob,
send suggestions to golob.mihael@gmail.com*
