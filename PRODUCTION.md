# PRODUCTION

Docs for how the server was setup

## Deploy

Deploy the code on the server. make sure the user as sudo access. You will be prompted for the sudo password around the end of the script.
`just deploy <username@server_ip>`

## Secret setup

Secrets are managed by a systemd override file. The file can be edited by using `sudo systemctl edit Rij62`
The override file looks something like this:

```
[Service]
Environment="Jwt__IssuerSigningKey=<production signing key>"
```

## Database setup

The database and user can be created with the following commands:

`sudo -u postgres psql postgres`

```sql
CREATE USER rij62 WITH PASSWORD 'rij62';
CREATE DATABASE rij62;
GRANT ALL PRIVILEGES ON DATABASE rij62 TO rij62;
```

`sudo -u postgres psql rij62`

```sql
GRANT ALL ON SCHEMA public TO rij62;
```

## Workaround for dotnet bug

For some reason the --idempotent script doesn't work on an empty database.
This can be fixed by generating a normal migration and applying it manually.

1. Generate the script `dotnet ef --project Rij62 migrations script  -o migrate.sql`
2. Than copy the migrate.sql file to the server `scp migrate.sql username@server_ip:/tmp/Rij62Migrate.sql`
3. Than apply it to the database under the rij62 user `cat /tmp/Rij62Migrate.sql | PGPASSWORD=rij62 psql -w rij62 rij62`

## Nginx

The nginx config is located at `/etc/nginx/Rij62.conf` which gets imported by the main nginx.conf file

## Restarting the server

The server can be restarted by running `sudo systemctl restart Rij62`
