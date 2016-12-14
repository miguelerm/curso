# Día 1

Este día veremos una introducción a [Docker][docker], cómo 
instalarlo y ponerlo en marcha. Para esto levantaremos un 
servidor web de pruebas con [nginx][nginx].

Terminaremos con una introducción a [Angular 2][ng2] para 
lo que nos apoyaremos en Docker para configurar nuestro 
ambiente de desarrollo y utilizaremos el servidor web *nginx*
para crear nuestro ambiente de producción.

Quedará pendiente para los siguientes días empezar a trabar
con [Docker Compose][docker-compose] y [Docker Swarm][docker-swarm].

[docker]: https://www.docker.com/
[nginx]: http://nginx.org/
[ng2]: https://angular.io/
[docker-compose]: https://docs.docker.com/compose/
[docker-swarm]: https://docs.docker.com/engine/swarm/

## Docker

### Conceptos básicos

**Container:** 

**Container Image:** 

**Container Registry:** 

**Docker Engine:**

**Dockerfile:** 

### Instalación de Docker en Windows

Docker para windows requiere [Hyper-V][HyperV] por lo que se debe habilitar
esta característica antes de instalar Docker.

Los primeros días utilizaremos solamente containers de Linux,
por lo que no es necesario contar con [Docker for Windows][Docker4Win], pero
si tenes Windows 10 y la versión es **Pro 1511, Build 10586** o superior podes instalar [Docker for Windows][Docker4Win].

Pero si tu versión de Windows es inferior a la ya mencionada
o incluso si es Windows 7 podes instalar [Docker Toolbox for Windows][DockerTools4Win].

[Docker4Win]: https://docs.docker.com/docker-for-windows/
[DockerTools4Win]: https://www.docker.com/products/docker-toolbox
[HyperV]: https://msdn.microsoft.com/en-us/virtualization/hyperv_on_windows/quick_start/walkthrough_install

### Referencias

* [Windows Containers Quick Start](https://msdn.microsoft.com/virtualization/windowscontainers/quick_start/quick_start)
* [What is docker?](https://www.docker.com/what-docker)