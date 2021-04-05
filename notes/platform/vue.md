# vue on ubuntu local

Running Ubuntu locally for development

## install applications

*Start With*

```bash
sudo apt update
sudo apt upgrade
```

### nodejs, npm, vue

```bash
sudo apt install nodejs
sudo apt install npm
```

[Node WSL Ubuntu](https://docs.microsoft.com/en-us/windows/nodejs/setup-on-wsl2)

```bash
# get nvm
curl -o- https://raw.githubusercontent.com/nvm-sh/nvm/v0.35.3/install.sh | bash

# close terminal

# confirm nvm (should return nvm)
command -v nvm

# see node envs
nvm ls

# install node
nvm install node

```

## install vue

```bash
npm install vue@next
```

## make project with vite 

```bash
npm init @vitejs/app spy-glass
cd spy-glass
npm install
npm run dev
```

## make project with vue cli + vuetify

```bash
vue create spy-glass
cd spy-glass
vue add vuetify

npm run dev
```

