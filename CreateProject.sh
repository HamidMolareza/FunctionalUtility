#! /bin/bash

#Save project name for easy use.
projectName="FunctionalUtility"

dotnet new sln

#ClassLib
dotnet new classlib -o $projectName
dotnet sln add $projectName/$projectName.csproj

#Console
dotnet new console -o ConsoleManualTest
dotnet sln add ConsoleManualTest/ConsoleManualTest.csproj

dotnet add ConsoleManualTest/ConsoleManualTest.csproj reference $projectName/$projectName.csproj

#Build project to make sure everything is right.
dotnet build
