# 📚 Documentación Técnica del Proyecto: .NET 8 con Docker y Git en Debian (WSL)

Este documento detalla de forma exhaustiva el proceso completo de ingeniería seguido para configurar, desarrollar, empaquetar y desplegar la aplicación web.

---

## 💻 1. Configuración del Entorno de Desarrollo (Debian en WSL)

El primer paso consistió en establecer una base sólida sobre Linux para garantizar un rendimiento óptimo de compilación y ejecución:

* **⚙️ Infraestructura Base:** Se utilizó Windows Subsystem for Linux (WSL2) ejecutando una distribución limpia de Debian GNU/Linux.

* **📦 Instalación y Verificación del .NET 8 SDK:** Se instaló el SDK oficial de Microsoft .NET 8 para poder compilar y gestionar paquetes NuGet directamente desde la terminal:
  ```bash
  dotnet --version

    🐳 Configuración del Motor de Contenedores: Se aseguró la correcta ejecución de Docker Engine dentro del subsistema Linux mediante el servicio de demonio:
    Bash

    sudo service docker start

📁 2. Creación y Estructura Inicial del Proyecto .NET 8

Una vez configurado el entorno, se inicializó el proyecto web de ASP.NET Core y se estructuró el espacio de trabajo.
Archivos principales generados:

    📄 Program.cs: Punto de entrada y configuración de las rutas de la aplicación web.

    📦 MiProyectoPrueba.csproj: Archivo de configuración y dependencias del framework .NET 8.

🧹 Limpieza de Artefactos Temporales:

Para evitar subir archivos innecesarios de compilación al control de versiones, se configuró un archivo .gitignore optimizado para excluir directorios transitorios (bin/, obj/).
🐳 3. Diseño del Dockerfile (Compilación Multi-Etapa / Multi-Stage Build)

Para garantizar que la imagen final de producción fuera ligera, segura y eficiente, se estructuró un Dockerfile optimizado en dos fases:
Dockerfile

# --- ETAPA 1: Entorno de Compilación (SDK completo) ---
FROM [mcr.microsoft.com/dotnet/sdk:8.0](https://mcr.microsoft.com/dotnet/sdk:8.0) AS build
WORKDIR /src
COPY ["MiProyectoPrueba.csproj", "./"]
RUN dotnet restore "MiProyectoPrueba.csproj"
COPY . .
RUN dotnet publish "MiProyectoPrueba.csproj" -c Release -o /app/publish

# --- ETAPA 2: Entorno de Ejecución (Runtime ligero) ---
FROM [mcr.microsoft.com/dotnet/aspnet:8.0](https://mcr.microsoft.com/dotnet/aspnet:8.0) AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "MiProyectoPrueba.dll"]

    💡 Explicación técnica: La primera etapa utiliza las herramientas pesadas de compilación (sdk:8.0) para generar los binarios limpios, mientras que la segunda etapa descarta el SDK y utiliza exclusivamente el runtime ligero de ASP.NET Core para producción.

🌐 4. Resolución de Incidencias en Git y GitHub

Durante la sincronización con el repositorio remoto (https://github.com/jose8951/dotnet-docker-web-demo.git), se aplicaron soluciones clave:

    🔀 Solución de conflictos (Non-fast-forward): Se unificaron los historiales independientes y se autenticó la operación mediante un Personal Access Token (PAT).

    👤 Identidad de Git: Se configuró el usuario y correo global para mantener trazabilidad profesional en los commits.

🚀 5. Guía de Construcción, Pruebas y Despliegue Web

Para poner en marcha la aplicación web en tu entorno local y verificar su funcionamiento en el navegador, sigue estos pasos:
🔨 Paso 1: Construir la imagen Docker

Navega a la raíz del proyecto y genera la imagen etiquetándola con un nombre descriptivo:
Bash

docker build -t miproyectoprueba .

⚡ Paso 2: Ejecutar el contenedor en segundo plano

Inicia la instancia mapeando el puerto 8080 de tu máquina anfitriona hacia el puerto 8080 interno del contenedor:
Bash

docker run -d -p 8080:8080 --name mi_app_dotnet miproyectoprueba

🌍 Paso 3: Probar la aplicación en la Web

Abre tu navegador web en Windows (Chrome, Edge, etc.) y accede a la siguiente dirección:
Plaintext

http://localhost:8080

📊 Paso 4: Monitoreo y Comandos Útiles

    Verificar el estado del contenedor:
    Bash

    docker ps

    Inspeccionar los registros (logs) en tiempo real:
    Bash

    docker logs -f mi_app_dotnet

    Detener el contenedor:
    Bash

    docker stop mi_app_dotnet
