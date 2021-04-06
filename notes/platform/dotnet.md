# dotnet

[Install on Ubuntu 20.04 LTS](https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu)

_Package Source_

```bash
wget https://packages.microsoft.com/config/ubuntu/20.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
```

_Development_

```bash
sudo apt-get update
sudo apt-get install -y apt-transport-https
sudo apt-get update
sudo apt-get install -y dotnet-sdk-5.0
```

_Production Runtime Only_

```bash
sudo apt update 
sudo apt install apt-transport-https 
sudo apt install aspnetcore-runtime-5.0 
```