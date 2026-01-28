# 🧪 Actividad 1: Rick & Morty API (BaaS)

![Angular](https://img.shields.io/badge/Angular-17+-dd0031?style=flat&logo=angular)
![.NET](https://img.shields.io/badge/.NET-8.0-512bd4?style=flat&logo=dotnet)
![MySQL](https://img.shields.io/badge/MySQL-8.0-4479a1?style=flat&logo=mysql)
![TailwindCSS](https://img.shields.io/badge/Tailwind-CSS-38bdf8?style=flat&logo=tailwindcss)

Solución técnica para la exploración de personajes del universo Rick & Morty, implementando una arquitectura **BFF (Backend for Frontend)**.

---

## Objetivo PT1

Verificar la capacidad de consumir una API externa a partir de su documentación oficial, implementando
listado, filtros, paginación, navegación a detalle y manejo de estados de interfaz, utilizando un backend
intermedio como capa de integración.

---

## 🏛️ Arquitectura de la Solución

El proyecto sigue un patrón de **Capas (Layered Architecture)** con separación de responsabilidades:

1.  **Frontend (Angular + Tailwind):** Interfaz moderna, responsiva y tipada. No consume la API pública directamente; todas las peticiones pasan por el Backend propio.
2.  **Backend (ASP.NET Core 8):**
    - Actúa como **API Gateway / BFF**.
    - Consume la API de Rick & Morty (`HttpClient`).
    - Enriquece la data (nombres de episodios, formateo).
    - Persiste logs de auditoría en MySQL.
3.  **Base de Datos (MySQL):** Almacena el historial de búsquedas y filtros utilizados por los usuarios.

---

## 🚀 Prerrequisitos

Asegúrate de tener instalado:

- Node.js (LTS)
- .NET 8 SDK
- MySQL Server

---

## 🛠️ Instrucciones de Instalación y Ejecución

### 1. Configuración de Base de Datos

1. Abra su cliente MySQL (Workbench, DBeaver).
2. Ejecute el script ubicado en `Database-PT1/schema.sql`.
3. Esto creará la BD `RickMortyDB` y la tabla `SearchHistory`.

### 2. Ejecución del Backend (.NET 8)

1. Navegue a la carpeta del backend:
   - cd Backend_PT1
2. Abra appsettings.json y configure su cadena de conexión en DefaultConnection (Usuario/Contraseña de MySQL).
3. Restaure los paquetes y ejecute:
   - dotnet restore
   - dotnet run
4. El servidor iniciará en: http://localhost:5285 (o el puerto indicado en consola).
   - Swagger disponible en: http://localhost:5285/swagger

### 3. Ejecución del frontend (Angular)

1. Abra una nueva terminal y navegue al frontend:
   - cd Frontend-PT1
2. Instale las dependencias:
   - npm install
3. Inicie el servidor de desarrollo:
   - ng serve -o
4. La aplicación se abrirá en el puerto:
   - http://localhost:4200.

---

## ✨ Funcionalidades Destacadas

1. Búsqueda Avanzada: Filtros combinados por Nombre, Especie, Tipo, Estado y Género.
2. Interfaz Moderna: Diseño limpio (Clean UI) utilizando Tailwind CSS con componentes tipo tarjeta 3D.
3. Traducción en Tiempo Real: Mapeo de datos (Alive -> Vivo) realizado en el cliente.
4. Detalle Enriquecido: Visualización de episodios con nombres reales (resolución de IDs en el Backend).
5. Auditoría: Cada búsqueda queda registrada en la base de datos para análisis futuro.

---

## 📂 Estructura del Proyecto

| Carpeta                        | Descripción                              |
| ------------------------------ | ---------------------------------------- |
| `/Backend`                     | API desarrollada en .NET 8               |
| `/Backend/Controllers`         | Endpoints expuestos al frontend          |
| `/Backend/Services`            | Lógica de negocio y consumo HTTP externo |
| `/Backend/Models`              | DTOs y entidades de base de datos        |
| `/Backend/Data`                | Contexto de Entity Framework             |
| `/Frontend`                    | Aplicación Angular Standalone            |
| `/Frontend/src/app/pages`      | Vistas (Home, Detail)                    |
| `/Frontend/src/app/services`   | Comunicación HTTP                        |
| `/Frontend/src/app/components` | Componentes UI reutilizables             |
| `/Database`                    | Scripts SQL                              |

---

Hecho por **Jorge Humberto Gomez De Avila (DESARROLLADOR FULLSTACK)** para la Prueba Técnica.
