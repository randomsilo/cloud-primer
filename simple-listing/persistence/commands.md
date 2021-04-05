# commands

```powershell
# windows terminal
cd C:\shop\randomsilo\dev\cloud-primer\simple-listing\persistence

# build postgres simple listing database image
docker build -t simple-listing-db-image simple-listing-db

# see images
docker images -a

# rum image detached
docker run -d --name simple-listing-db-container -p 5555:5432 simple-listing-db-image

# stop container
docker stop simple-listing-db-container

# re-start container
docker container start simple-listing-db-container

```