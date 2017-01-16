#!/bin/sh

fastcgi-mono-server4 /applications=/:/var/www/app/ /socket=tcp:$(ip -4 addr show eth0 | grep -Po 'inet \K[\d.]+'):9000