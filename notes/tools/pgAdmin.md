# pgAdmin

[Download](https://www.pgadmin.org/download/pgadmin-4-windows/)

> Connect to postgres containers using 'host.docker.internal' instead of 'localhost' on Windows 10


[Ubuntu Client](https://help.ubuntu.com/community/PostgreSQL)

```bash
# run from WSL Ubuntu
sudo apt-get install postgresql-client

# run client
psql -h host.docker.internal database user

# run sql
SELECT * FROM table WHERE 1;

# quit
\q
```