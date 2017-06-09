[![Build Status](https://travis-ci.org/partei/webapp.svg?branch=master)](https://travis-ci.org/partei/webapp)

# Partei Webapp

## Prerequisite

- .NET Core SDK 1.0.1
- node 8.0.0
- npm 5.0.0

## Run application without docker

```shell
cd Application
npm install
npm build
dotnet restore
dotnet run
```

Browse to http://localhost:5001/.

## Run application with docker

```shell
docker run -p 5001:5001 robisrob/partei-webapp:TAG
```

Browse to http://localhost:5001/.

After every successful build, a new image is pushed to https://hub.docker.com/r/robisrob/partei-webapp/.

## Send request

- POST 
 - url: http://localhost:5001/api/photo
 - headers: Content-Type: application/json

## Run tests

```shell
dotnet restore ./Application.Tests/Application.Tests.csproj
dotnet test ./Application.Tests/Application.Tests.csproj
```

