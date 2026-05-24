#!/bin/bash
set -e
USAGE="Usage: $0 <USERNAME>@<SERVER_IP>
Upload test images to the production server
"

DESTDIR_ON_SERVER="/var/Rij62/image-db"

cd $(dirname $0)

if [[ -z "$1" ]] || [[ "$1" == "--help" ]] ; then
  echo "$USAGE"
  exit 1
fi

SERVER_SSH="$1"


echo "Tarring it up!"
tar -czvf Rij62Images.tar.gz -C ./testDataImages .

echo "Uploading..."
scp Rij62Images.tar.gz $SERVER_SSH:/tmp/Rij62Images.tar.gz
scp testData.sql $SERVER_SSH:/tmp/testData.sql

ssh $SERVER_SSH "sudo -S /bin/sh -c '
mkdir -p $DESTDIR_ON_SERVER
tar -xzvf /tmp/Rij62Images.tar.gz -C $DESTDIR_ON_SERVER

cat /tmp/testData.sql | psql rij62 rij62

rm -f /tmp/Rij62Images.tar.gz
rm -f /tmp/testData.sql
'"
