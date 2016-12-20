# Día 1

Este día veremos una introducción a [Docker][docker], cómo instalarlo y ponerlo
en marcha. Para esto levantaremos un servidor web de pruebas con [nginx][nginx].

Terminaremos con una introducción a [NodeJs][node] para lo que nos apoyaremos en
Docker para configurar nuestro ambiente de desarrollo y utilizaremos el servidor
web *nginx* para crear nuestro ambiente de producción que básicamente será
implementar un Load Balancer entre dos nodos que estarán sirviendo la aplicación
Node.

Quedará pendiente para los siguientes días empezar a trabar con [Docker
Compose][docker-compose] y [Docker Swarm][docker-swarm].

[docker]: https://www.docker.com/
[nginx]: http://nginx.org/
[node]: https://nodejs.org/
[docker-compose]: https://docs.docker.com/compose/
[docker-swarm]: https://docs.docker.com/engine/swarm/

## Docker

### Conceptos básicos

**Container:** Es un ambiente portatil, completamente aislado y controlado en el
que podemos ejecutar aplicaciones sin que estas afecten a otras aplicaciones o
al sistema operativo.

**Container Image:** La imagen de un contenedor posee el sistema operativo
base, la aplicación que se va a ejecutar y todas las dependencias de esta
aplicación.

**Container Registry:** Es un repositorio desde el cual se pueden descargar
imagenes que se pueden reutilizar en nuestras aplicaicones.

**Docker Engine:** Es la plataforma que permite ejecutar y gestionar los
contenedores de docker.

**Dockerfile:** Es un archivo que nos permite especificar todos los
requerimientos de cada uno de nuestras imagenes para poder automatizar el
proceso de construcción de estas.

### Instalación de Docker en Windows

Docker para windows requiere [Hyper-V][HyperV] por lo que se debe habilitar esta
característica antes de instalar Docker.

Los primeros días utilizaremos solamente containers de Linux, por lo que no es
necesario contar con [Docker for Windows][Docker4Win], pero si tenes Windows 10
y la versión es **Pro 1511, Build 10586** o superior podes instalar [Docker for
Windows][Docker4Win].

Pero si tu versión de Windows es inferior a la ya mencionada o incluso si es
Windows 7 podes instalar [Docker Toolbox for Windows][DockerTools4Win].

[Docker4Win]: https://docs.docker.com/docker-for-windows/
[DockerTools4Win]: https://www.docker.com/products/docker-toolbox
[HyperV]: https://msdn.microsoft.com/en-us/virtualization/hyperv_on_windows/quick_start/walkthrough_install

### Demo

#### Servidor Web Estático:

Iniciar el contenedor de docker basado en nginx apuntando a la carpeta de un 
sitio estático.

```sh
docker run --name my-site -p 8989:80 -v c:/users/mike/projects/curso/dia-001/static-site:/usr/share/nginx/html:ro -d nginx
```

atachando al container de docker para ejecutar comandos en el bash.

```sh
docker exec -it my-site /bin/bash
```

#### Dockerfile para un sitio estático:

Creacion del Dockerfile con este contenido en la carpeta static-site-a:

```txt
FROM nginx
COPY html /usr/share/nginx/html
```

Construcción de la imagen basada en ese dockerfile (ejecutar comando en la
misma carpeta que el Dockerfile):

```sh
docker build -t mi-sitio-web .
```

Ejecución de un nuevo contenedor basado en la imagen creada.

```sh
docker run --name mi-sitio-web-a -p 8888:80 -d mi-sitio-web
```

#### Dockerfile para una aplicación con NodeJS:

ver aplicacion en el folder `node-app`.

El dockerfile se basa en `node:onbuild` que es un container que restaura
todas las dependencias de la aplicación y lo unico que le agrega es la
exposición del puerto:

```txt
FROM node:onbuild
EXPOSE 80
```

Construir la imagen:

```sh
docker build -t mi-node-app .
```

```sh
docker run -d -p 8889:80 --name mi-node-app-a mi-node-app
```

#### Balanceo de carga del sitio estático:

Crear la red virtual:

```sh
docker network create red-de-mi-sitio
```

verificar que se creó correctamente la red:

```sh
docker network inspect red-de-mi-sitio
```

Iniciando los dos nodos:

```sh
docker run --net red-de-mi-sitio --name nodo-a -d mi-node-app
docker run --net red-de-mi-sitio --name nodo-b -d mi-node-app
```

Configuración del Load Balancer para nginx:

```txt
http {
    upstream mi-sitio {
        server nodo-a;
        server nodo-b;
    }

    server {
        listen 80;

        location / {
            proxy_pass http://mi-sitio;
        }
    }
}
```

Ejecutar nginx para utilizar el archivo de configuración para
balanceo de cargas.

```sh
docker run --net red-de-mi-sitio --name proxy-server -p 8890:80 -v c:/users/mike/projects/curso/dia-001/default-nginx-balancer.conf:/etc/nginx/nginx.conf:ro -d nginx
```

### Referencias

* [Windows Containers Quick
  Start](https://msdn.microsoft.com/virtualization/windowscontainers/quick_start/quick_start)
* [What is docker?](https://www.docker.com/what-docker)
