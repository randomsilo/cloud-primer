# docker

## web links

[Better than Env](https://diogomonica.com/2017/03/27/why-you-shouldnt-use-env-variables-for-secret-data/)

```bash
# make the secret
openssl rand -base64 32 | docker secret create secure-secret -

# pass the secret
docker service create --secret="secure-secret" redis:alpine

# read the secret
cat /run/secrets/secure-secret
eHwX8kV8sFt/y30WASgz8kimnKhUkCrt07XMrmewYr8=
```