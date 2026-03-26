set windows-shell := ["powershell.exe", "-NoLogo", "-Command"]

run: start-db
    dotnet run --project Rij62

start-db:
    docker compose up -d

db-shell:
  docker compose exec -i db /bin/psql

clear-db:
    echo "DROP SCHEMA public CASCADE;CREATE SCHEMA public;" | docker compose exec --no-tty db /bin/psql
    dotnet ef --project Rij62 database update

load-db-test-data: clear-db
  cat testData.sql | docker compose exec --no-tty db /bin/psql

init: load-db-test-data
