USAGE="Usage: $0 <USERNAME>@<SERVER_IP>
Deploy code to production on the server specified
"

DESTDIR_ON_SERVER="/opt/Rij62"

cd $(dirname $0)

if [[ -z "$1" ]] || [[ "$1" == "--help" ]] ; then
  echo "$USAGE"
  exit 1
fi

SERVER_SSH="$1"

echo "Pushing to: $SERVER_SSH"

echo "Building..."
dotnet publish --self-contained --os linux --arch x64

echo "Generating migrations..."
dotnet ef --project Rij62 migrations script --idempotent -o migrate.sql

echo "Tarring it up!"
tar -czvf Rij62.tar.gz -C ./Rij62/bin/Release/net10.0/linux-x64/publish .

echo "Pushing..."

scp ./Rij62.service $SERVER_SSH:/tmp/Rij62.service
scp Rij62.tar.gz $SERVER_SSH:/tmp/Rij62.tar.gz
scp migrate.sql $SERVER_SSH:/tmp/Rij62Migrate.sql

ssh $SERVER_SSH "sudo -S /bin/sh -c '
rm -rf $DESTDIR_ON_SERVER && mkdir -p $DESTDIR_ON_SERVER
tar -xzvf /tmp/Rij62.tar.gz -C $DESTDIR_ON_SERVER

mv /tmp/Rij62.service /etc/systemd/system/
rm -f /tmp/Rij62.tar.gz

systemctl daemon-reload
systemctl stop Rij62

echo Applying migrations
cat /tmp/Rij62Migrate.sql | PGPASSWORD=rij62 psql -w rij62 rij62

systemctl restart Rij62
'"
