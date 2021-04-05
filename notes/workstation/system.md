# Dell XPS

* 64g Ram
* 2g SSD
* 4g HD
* i7 8 cores

## Software

### Browsers

* Edge
* Chrome
 * [Vue Extension](https://chrome.google.com/webstore/detail/vuejs-devtools/ljjemllljcmogpfapbkkighbhhppjdbg) 
* Firefox
 * [Vue Extension](https://addons.mozilla.org/en-US/firefox/addon/vue-js-devtools/?utm_source=addons.mozilla.org&utm_medium=referral&utm_content=search)
* Tor

### Utility

 *(Chocolatey)[https://chocolatey.org/courses/installation/installing?method=installing-chocolatey]*

```
@"%SystemRoot%\System32\WindowsPowerShell\v1.0\powershell.exe" -NoProfile -InputFormat None -ExecutionPolicy Bypass -Command "iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))" && SET "PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin"
``` 

```
choco install inkscape
choco install gimp
choco install notepadplusplus
choco install curl
```

### Kubernetes

[WSL 2](https://www.omgubuntu.co.uk/how-to-install-wsl2-on-windows-10)

```powershell
# WSL 2
dism.exe /online /enable-feature /featurename:Microsoft-Windows-Subsystem-Linux /all /norestart

# Virtual Machine Platform
Enable-WindowsOptionalFeature -Online -FeatureName VirtualMachinePlatform -NoRestart

### RESTART

# Windows Store: Ubuntu 20.04 LTS

# Windows Terminal 

```

[WSL Distros](https://docs.microsoft.com/en-us/windows/wsl/install-manual)

[Kubernetes](https://kubernetes.io/blog/2020/05/21/wsl-docker-kubernetes-on-the-windows-desktop/)

### Ubuntu

```bash
# update
sudo apt update

# upgrade
sudo apt upgrade -y
```

#### Install Software

### Docker for Windows Desktop

[Docker Install Instructions](https://docs.docker.com/docker-for-windows/install/)
[Download](https://hub.docker.com/editions/community/docker-ce-desktop-windows/)

#### Docker Settings

* Enable Kubernetes
* Deploy Docker Stacks to Kubernetes by Default
* Show System Containers 

#### Confirm Ubuntu Kubernetes Access

```bash
# Try to see if the docker cli and daemon are installed
docker version
# Same for kubectl
kubectl version
```

