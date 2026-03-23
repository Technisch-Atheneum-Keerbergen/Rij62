set windows-shell := ["powershell.exe", "-NoLogo", "-Command"]

run:
    dotnet run --project Rij62

reset-db:
    echo "DROP SCHEMA public CASCADE;CREATE SCHEMA public;" | docker compose exec --no-tty db /bin/psql
    dotnet ef --project Rij62 database update

create-user:
    echo "INSERT INTO users(id, DisplayName, is_admin) VALUES (0, 'Mr delux', true);" | docker compose exec --no-tty db /bin/psql
