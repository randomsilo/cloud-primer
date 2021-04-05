# kubernetes

## prerequists

* apply ./workstation/system.md

## setup

[First Cluster](https://kubernetes.io/blog/2020/05/21/wsl-docker-kubernetes-on-the-windows-desktop/)

## KinD

[QuickStart](https://kind.sigs.k8s.io/docs/user/quick-start/)

```powershell
# install kind
choco install kind
```

### Commands

```powershell
# create cluster
kind create cluster --name dawson

# use cluster
kubectl cluster-info --context kind-dawson

# delete cluster (don't do unless you are done)
kind delete cluster --name dawson

# add docker images
kind load docker-image my-custom-image-0 my-custom-image-1
```

### Possible Workflow

```powershell
docker build -t my-custom-image:unique-tag ./my-image-dir

kind load docker-image my-custom-image:unique-tag

kubectl apply -f my-manifest-using-my-image:unique-tag
```

## Istio Control Plane

[istio](https://istio.io/latest/docs/setup/getting-started/)

[kind](https://istio.io/latest/docs/setup/platform-setup/kind/)

### Switch to Cluster 

```powershell
# make sure cluster is up
kubectl config get-contexts

# swithc to kind cluster 
kubectl config use-context kind-dawson
```

### Install

[How to install on Windows 10](https://gist.github.com/VidyasagarMSC/2dcb760297f97220fb5e24621c606d76)

[Istio Rleases](https://github.com/istio/istio/releases)

```powershell
# Install istioctl-1.9.2-win.zip

# Explode Zip

# Add Folder to Env

# Check your work
istioctl version
```

#### Dashboard

```powershell
# To deploy Dashboard, run the following command
kubectl apply -f https://raw.githubusercontent.com/kubernetes/dashboard/v2.1.0/aio/deploy/recommended.yaml

# Verify that Dashboard is deployed and running
kubectl get pod -n kubernetes-dashboard

# Create a ClusterRoleBinding to provide admin access to the newly created cluster 
kubectl create clusterrolebinding default-admin --clusterrole cluster-admin --serviceaccount=default:default

# To login to Dashboard, you need a Bearer Token. Use the following command to store the token in a variable.
## linux
token=$(kubectl get secrets -o jsonpath="{.items[?(@.metadata.annotations['kubernetes\.io/service-account\.name']=='default')].data.token}"|base64 --decode)

## windows
kubectl get secrets -o jsonpath="{.items[?(@.metadata.annotations['kubernetes\.io/service-account\.name']=='default')].data.token}"

# proxy
kubectl proxy

```


[dashboard: login screen](http://localhost:8001/api/v1/namespaces/kubernetes-dashboard/services/https:kubernetes-dashboard:/proxy/#/login)

[Base64 Decoder](https://www.base64decode.org/)

[Micro Services](https://istio.io/latest/docs/examples/microservices-istio/)

[Micro Service Example](https://istio.io/latest/docs/examples/microservices-istio/single/)