# simple listing vue

## setup application

```bash
# create web app
vue create simple-listing-vue
## - select Vue 3

# change into project directory
cd ./simple-listing-vue

# install prime vue for vue3
npm install primevue@^3.3.5 --save
npm install primeicons --save

# install dependencies
rm package-lock.json
rm -rf node_modules
npm install

# run vue
npm run serve

# check
# App running at:
#  - Local:   http://localhost:8080/ 
#  - Network: http://172.17.175.26:8080/

```


## End to End

From admin powershell on k8 machine, start database and api.

```bash
# start database container
docker run -d --name simple-listing-db-container -p 5432:5432 simple-listing-db-image

# start api container
cd C:\shop\randomsilo\dev\cloud-primer\simple-listing\services\sentence\sentence.api
dotnet run
```

From Ubuntu WSL VS Code Instance 

```bash
# run vue
npm run serve

# check
# App running at:
#  - Local:   http://localhost:8080/ 
#  - Network: http://172.17.175.26:8080/
```

Use chrome browser with CORS disabled.

```bash
"C:\Program Files\Google\Chrome\Application\chrome.exe" --user-data-dir="C:/ChromeDevSession" --disable-web-security
```