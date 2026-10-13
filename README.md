🛠️ 1. Entorno y Tecnologías

    Sistema / Entorno: Debian GNU/Linux ejecutándose en WSL2 (Windows Subsystem for Linux).

    Framework: .NET 8.0 (ASP.NET Core).

    Contenedorización: Docker (con compilación multi-stage).

    Control de Versiones: Git y GitHub.

📋 2. Pasos y Soluciones Realizadas
A. Limpieza y Configuración del Repositorio Local

    Se eliminaron y excluyeron los archivos temporales y directorios binarios (bin/, obj/) mediante un archivo .gitignore estricto.

    Se solucionaron los conflictos de historial divergente con GitHub utilizando tokens de acceso personal (PAT) y unificación de ramas remotas.

B. Empaquetado y Dockerización

    Se diseñó un Dockerfile optimizado en dos etapas (SDK para compilación y Runtime ligero para producción).

    Se construyó y ejecutó la imagen de Docker mapeando el puerto 8080:
    Bash

    docker build -t miproyectoprueba .
    docker run -d -p 8080:8080 --name mi_app_dotnet miproyectoprueba

C. Documentación Profesional (README.md)

    Se estructuró un README.md exhaustivo de más de 40 líneas que detalla los requisitos previos, la guía paso a paso de clonación, comandos de gestión de Docker y resolución de incidencias (troubleshooting).

📁 3. Estructura Final del Proyecto

    Program.cs: Punto de entrada de la aplicación.

    MiProyectoPrueba.csproj: Definición del proyecto .NET 8.

    Dockerfile: Configuración del contenedor Docker.

    .gitignore: Control de exclusiones para Git.

    README.md: Documentación técnica del repositorio en GitHub." title="Resumen_Proyecto_DotNet_Docker_GitHub.md"/>
