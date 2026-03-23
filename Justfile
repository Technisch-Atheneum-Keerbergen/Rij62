set windows-shell := ["powershell.exe", "-NoLogo", "-Command"]

run: start-db
    dotnet run --project Rij62

start-db:
    docker compose up -d

reset-db:
    echo "DROP SCHEMA public CASCADE;CREATE SCHEMA public;" | docker compose exec --no-tty db /bin/psql
    dotnet ef --project Rij62 database update

create-user:
    echo "INSERT INTO users(id, display_name, is_admin) VALUES (0, 'Mr delux', true);" | docker compose exec --no-tty db /bin/psql

init: reset-db create-user
