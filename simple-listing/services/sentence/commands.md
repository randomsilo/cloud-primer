# commands

```powershell
# windows terminal
cd /shop/randomsilo/dev/cloud-primer/simple-listing/services/sentence

# build application
dotnet restore
dotnet build

# publish api
cd ./sentence.api
dotnet publish -c Release -o published

# output files should be in:
# /shop/randomsilo/dev/cloud-primer/simple-listing/services/sentence/sentence.api/published

# build postgres simple listing database image
cd /shop/randomsilo/dev/cloud-primer/simple-listing/services/sentence
docker build -t sentence.api-image .

# see images
docker images -a

# rum image detached
docker run -d --rm -p 8101:8101 -p 8100:8100 -e ASPNETCORE_HTTPS_PORT=https://+:8101 -e ASPNETCORE_URLS=http://+:8100 --name sentence.api-image-container sentence.api-image


# start container
docker container start sentence.api-image-container

# stop container
docker stop sentence.api-image-container

# start container
docker container start sentence.api-image-container

# start over
docker rm sentence.api-image-container
docker image rm sentence.api-image
```

```bash
http://localhost:8100/Sentence
```