# simple listing

* Vue3 Vuetify web application
* dotnet Restful API
* PostgresSQL

# develop

Three tier application with basic crud listing.

## Vue3 Web Application

The landing page will be a listing of the last ten sentences entered.
A plus sign at the bottom of the listing will pop up a dialog box that can be used to enter another sentence.
A pencil icon on each listing will be used to pop a dialog boc with the existing sentence for update.
A trash can icon n each listing will be used to delete a sentence.
A large empty message will appear if all sentences have been deleted.

> Pagination will be added after these core features have been added.

> RabbitMQ messeging for concurrant record access and live record updates.

## dotnet Restful API

dotnet API that can add, update, and delete a setence entry in a PostgresSql.

## PostgresSQL

Maintain persistence for an active record pattern table named sentence with three columns: id, sentence, created_on, and updated_on.

> Connect to postgres containers using 'host.docker.internal' instead of 'localhost' on Windows 10

# dockerize

Make each tier into a deployable image.

# cloud deploy

Create a cluster with the images.
Setup istio service mesh to make each tier reachable.

> Install different dashboard to examine your cluster.