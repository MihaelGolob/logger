# Ineor Log System package

This is a Log system package based on the Serilog library. It currently supports logging to 
the Unity Console and to a file on the system. It can automatically log exceptions/crashes to
a file before the application crashes.

## How to use
1. Add the package to your project
2. To enable logs you need to globally define the `ENABLE_LOGS` symbol. This can be done either
by including it in every script where you need logs or by going to `Unity->Edit->Project Settings->Player->Other Settings->Scripting Define Symbols`

4. Start logging messages.

*Created by Mihael Golob,
send suggestions to golob.mihael@gmail.com*
