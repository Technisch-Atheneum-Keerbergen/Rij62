set windows-shell := ["powershell.exe", "-NoLogo", "-Command"]

run:
    dotnet run --project Rij62

reset-db:
    echo "DROP SCHEMA public CASCADE;CREATE SCHEMA public;" | docker compose exec --no-tty db /bin/psql
    dotnet ef database update