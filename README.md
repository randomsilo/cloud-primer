# cloud-primer

Experiments with K8.

## setup

I am using a Windows 10 pc with Ubuntu 20.04 LTS (WSL).
Development will be in VS Code connected to the WSL.
I am keeping the development in linux to keep the docker file surprises to a minimum.

Docker for Windows has been installed with kubernetes, kind, and istio.
I will try to specify where (which platform) the command is being executed on.

## three step process

1. Develop Software
2. Dockerize Software into an Image
3. Cloud Deploy Image

The standard three tier setup: client (user interface), middleware (api), and persistence (database) is still there.
Each tier will have its own platform (docker image) with your software running in isolation.

> This is the exact opposite of a LAMP stack; which puts the web server, api server, and database on the same physical server behind a software firewall.
> LAMP stacks are easy to setup; but, are limited to vertical scaling.

Kubernetes has own internal network that it uses to manage clusters.
A cluster has a defined configuration of deployed images.
It will add, remove, and restart images to maintain an ideal state.
The images do not need to exist on the same physical hardware which allows for elastic/horizontal scaling.

The goal is to learn the basics of kubernetes and develop best practices for real world applications. 