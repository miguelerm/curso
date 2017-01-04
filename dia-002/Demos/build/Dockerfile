FROM mono:latest

RUN apt-get update && \
    apt-get install -y mono-fastcgi-server4 && \
    rm -rf /var/lib/apt/lists/* /tmp/*

ADD ./app /var/www/app/
ADD ./mono-fastcgi.sh /opt/mono-fastcgi.sh
RUN chmod +x /opt/mono-fastcgi.sh

EXPOSE 9000

CMD [ "/opt/mono-fastcgi.sh" ]