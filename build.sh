#!/bin/bash

echo "Compiling for Windows , Mac and Linux"
dotnet publish -r win-x64
dotnet publish -r linux-x64
dotnet publish -r osx-x64