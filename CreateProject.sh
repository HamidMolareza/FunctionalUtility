#! /bin/bash

#Save project name for easy use.
projectName="FunctionalUtility"

#Create sln.
dotnet new sln

dotnet new classlib -o $projectName
dotnet sln add $projectName/$projectName.csproj

#Build project to make sure everything is right.
dotnet build
