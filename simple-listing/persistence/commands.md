# commands

```powershell
# windows terminal
cd C:\shop\randomsilo\dev\cloud-primer\simple-listing\persistence

# build postgres simple listing database image
docker build -t simple-listing-db-image simple-listing-db

# see images
docker images -a

# rum image detached
docker run -d --name simple-listing-db-container -p 5432:5432 simple-listing-db-image

# start container
docker container start simple-listing-db-container

# stop container
docker stop simple-listing-db-container

# start container
docker container start simple-listing-db-container

# start over
docker rm simple-listing-db-container
docker image rm simple-listing-db-image
```


```bash
# WSL test
psql -h host.docker.internal database user
```