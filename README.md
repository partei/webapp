[![Build Status](https://travis-ci.org/partei/webapp.svg?branch=master)](https://travis-ci.org/partei/webapp)

# Partei Webapp

## Prerequisite
.NET Core SDK 1.0.1

## Run application without docker
- cd Application
- dotnet restore
- dotnet run

## Run application with docker
- docker run -p 5001:5001 robisrob/partei-webapp
    - (after every successful build, a new image is pushed to https://hub.docker.com/r/robisrob/partei-webapp/)

## Send request
- POST 
 - url: http://localhost:5001/api/gameoflife
 - headers: Content-Type: application/json

## Run tests
 - dotnet restore ./Application.Tests/Application.Tests.csproj
 - dotnet test ./Application.Tests/Application.Tests.csproj

