# dotnet

[Install on Ubuntu 20.04 LTS](https://tecadmin.net/how-to-install-net-core-on-ubuntu-20-04/)

_Package Source_

```bash
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb 
sudo dpkg -i packages-microsoft-prod.deb
```

_Development_

```bash
sudo apt update 
sudo apt install apt-transport-https 
sudo apt install dotnet-sdk-3.1
```

_Production Runtime Only_

```bash
sudo apt update 
sudo apt install apt-transport-https 
sudo apt install dotnet-runtime-3.1 
```