# commands

## simple-listing-api

### create project

_Ubuntu Linux WSL_

```bash
# goto base project directory
cd /shop/randomsilo/dev/cloud-primer/simple-listing

# goto services
cd ./services

# make directory
mkdir ./simple-listing-api

# change directory
cd ./simple-listing-api

# make web api project
dotnet new webapi
```

### run api

```bash
# change directory
cd /shop/randomsilo/dev/cloud-primer/simple-listing/services/simple-listing-api

# run 
dotnet run

# publish
dotnet publish
```