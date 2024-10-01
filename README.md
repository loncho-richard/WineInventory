
# Documentación de la API - Gestión de Usuarios y Vinos

## Descripción

Esta API permite la gestión de usuarios y vinos. Consta de tres endpoints: uno para la creación de usuarios, otro para la creación de vinos y uno más para obtener la lista de vinos disponibles.

La API está desarrollada en C# con .NET, utilizando Entity Framework y SQLite como base de datos.

## Requisitos Previos

1. **Dependencias**:
   - .NET SDK (versión compatible)
   - Entity Framework Core
   - SQLite

2. **Variables de entorno** (si aplica).

3. **Configuración de la base de datos**:
   La base de datos se crea y gestiona automáticamente con Entity Framework utilizando SQLite.

## Instalación

1. Clona el repositorio:

   ```bash
   git clone https://github.com/tuusuario/tu-repositorio.git
   cd tu-repositorio
   ```

2. Restaura las dependencias de .NET:

   ```bash
   dotnet restore
   ```

3. Aplica las migraciones para crear la base de datos SQLite:

   ```bash
   dotnet ef database update
   ```

4. Ejecuta el proyecto:

   ```bash
   dotnet run
   ```

## Uso de la API

### Endpoints

#### 1. Crear Usuario

- **POST** `/user/`
  
  Este endpoint permite la creación de un nuevo usuario.

  **Body de la solicitud:**

  ```json
  {
    "username": "string",
    "password": "stringstri"
  }
  ```

  **Códigos de respuesta:**

  - **201 Created**: El usuario fue creado exitosamente.
  - **400 Bad Request**: 
    - El nombre de usuario ya existe.
    - El body de la solicitud es nulo o contiene errores.

  **Ejemplo de solicitud con `curl`:**

  ```bash
  curl -X POST http://localhost:5014/user/     -H "Content-Type: application/json"     -d '{
          "username": "usuario123",
          "password": "contraseñaSegura"
        }'
  ```

#### 2. Crear Vino

- **POST** `/wine/`
  
  Este endpoint permite la creación de un nuevo vino en el sistema.

  **Body de la solicitud:**

  ```json
  {
    "name": "string",
    "variety": "string",
    "year": 0,
    "region": "string",
    "stock": 0
  }
  ```

  **Códigos de respuesta:**

  - **201 Created**: El vino fue creado exitosamente.
  - **400 Bad Request**: 
    - El nombre del vino ya existe.
    - El body de la solicitud es nulo o contiene errores.

  **Ejemplo de solicitud con `curl`:**

  ```bash
  curl -X POST http://localhost:5014/wine/     -H "Content-Type: application/json"     -d '{
          "name": "Cabernet Sauvignon",
          "variety": "Tinto",
          "year": 2020,
          "region": "Mendoza",
          "stock": 100
        }'
  ```

#### 3. Obtener Lista de Vinos

- **GET** `/wine/`

  Este endpoint permite obtener la lista de vinos disponibles.

  **Códigos de respuesta:**
  
  - **200 OK**: Devuelve la lista de vinos.

  **Ejemplo de solicitud con `curl`:**

  ```bash
  curl -X GET http://localhost:5014/wine/
  ```

## Códigos de Estado

- **201 Created**: El recurso fue creado exitosamente.
- **400 Bad Request**: Error en la solicitud, ya sea por datos duplicados o por un body incorrecto.
- **200 OK**: Solicitud exitosa, datos obtenidos correctamente.

