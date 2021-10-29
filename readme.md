# TLS/SSL test with .NET and Postgresql

Test using Npgsql driver with TLS in a .NET application with Postgresql docker image provided by Bitnami.

## Generate TLS certificates:

    cd certs
    ./gen.sh

Note: Make sure `default_md` is set to `sha256` in /etc/ssl/openssl.cnf and last version of OpenSSL 3+ is used.

## Run the project:

    docker-compose up

    or

    docker-compose up -d

## Expected result:

You should see the application (myapp) writing `Count=<some-number>` in the console as soon as the DB starts.

Example:

```
...
pgdemo-db-1     | postgresql 07:06:20.14 INFO  ==> ** Starting PostgreSQL **
pgdemo-db-1     | 2021-10-29 07:06:20.187 GMT [1] LOG:  pgaudit extension initialized
pgdemo-db-1     | 2021-10-29 07:06:20.198 GMT [1] LOG:  listening on IPv4 address "0.0.0.0", port 5432
pgdemo-db-1     | 2021-10-29 07:06:20.198 GMT [1] LOG:  listening on IPv6 address "::", port 5432
pgdemo-db-1     | 2021-10-29 07:06:20.202 GMT [1] LOG:  listening on Unix socket "/tmp/.s.PGSQL.5432"
pgdemo-db-1     | 2021-10-29 07:06:20.221 GMT [95] LOG:  database system was shut down at 2021-10-29 07:06:15 GMT
pgdemo-db-1     | 2021-10-29 07:06:20.238 GMT [1] LOG:  database system is ready to accept connections
pgdemo-myapp-1  | Count=1
pgdemo-myapp-1 exited with code 0
```