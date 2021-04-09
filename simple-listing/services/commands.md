# commands

## simple-listing-api

### create project

_Ubuntu Linux WSL_

```bash
# goto base project directory
cd /shop/randomsilo/dev/cloud-primer/simple-listing

PROJECT=sentence

# make directories
mkdir -p ./services/$PROJECT/$PROJECT.api
mkdir -p ./services/$PROJECT/$PROJECT.domain
mkdir -p ./services/$PROJECT/$PROJECT.test

# change directory to services/$PROJECT
cd ./services/$PROJECT

# make solution
dotnet new sln

# api project
cd $PROJECT.api
dotnet new webapi
cd ..

# domain project
cd $PROJECT.domain
dotnet new classlib
cd ..

# test project
cd $PROJECT.test
dotnet new xunit
cd ..

## add projects to the solution
dotnet sln $PROJECT.sln add $PROJECT.api/$PROJECT.api.csproj
dotnet sln $PROJECT.sln add $PROJECT.domain/$PROJECT.domain.csproj
dotnet sln $PROJECT.sln add $PROJECT.test/$PROJECT.test.csproj

## references

dotnet add $PROJECT.api/$PROJECT.api.csproj reference $PROJECT.domain/$PROJECT.domain.csproj
dotnet add $PROJECT.test/$PROJECT.test.csproj reference $PROJECT.domain/$PROJECT.domain.csproj

## packages

cd $PROJECT.domain
dotnet add package Npgsql
dotnet add package Dapper
dotnet add package Serilog
dotnet add package BCrypt.Net-Next
cd ..

cd $PROJECT.test
dotnet add package Bogus
dotnet add package Serilog
dotnet add package Serilog.Sinks.Console
dotnet add package Serilog.Sinks.File
dotnet add package Microsoft.NET.Test.Sdk
dotnet add package xunit.runner.visualstudio
cd ..

cd $PROJECT.api
dotnet add package Autofac
dotnet add package Autofac.Extensions.DependencyInjection
dotnet add package Dapper
dotnet add package Serilog
dotnet add package Serilog.Sinks.Console
dotnet add package Serilog.Sinks.File
cd ..

```

### run api

```bash
# change directory
cd /shop/randomsilo/dev/cloud-primer/simple-listing/services/sentence/sentence.api

# run 
dotnet run

# publish
dotnet publish
```