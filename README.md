# Sistema de Cable e Internet

Aplicación web desarrollada como prueba técnica para la administración de clientes, servicios y contratos de una empresa proveedora de internet.

## Tecnologías

- C# y ASP.NET Core MVC (.NET 8)
- SQL Server
- ADO.NET mediante `Microsoft.Data.SqlClient`
- Arquitectura por capas: presentación (MVC), lógica de negocio (BLL) y acceso a datos (DAL)
- Bootstrap, jQuery y validaciones del lado del cliente

## Estructura del repositorio

```text
/
├── Prueba_Caso.sql
├── README.md
├── .gitignore
├── SistemaCableInternet/
│   ├── SistemaCableInternet.sln
│   ├── SistemaCableInternet.csproj
│   ├── Controllers/
│   ├── Models/
│   ├── Views/
│   └── wwwroot/
├── SistemaCableInternet.BLL/
│   ├── Interfaces/
│   ├── Models/
│   └── Services/
└── SistemaCableInternet.DAL/
    ├── Connections/
    └── Repositories/
```

## Requisitos

- Windows
- Visual Studio 2022 (con la carga de trabajo **ASP.NET y desarrollo web**) o .NET 8 SDK
- SQL Server (por ejemplo, SQL Server 2019 o posterior)
- SQL Server Management Studio (SSMS), recomendado para ejecutar el script

## Configuración de la base de datos

1. Inicie SQL Server y abra SQL Server Management Studio.
2. Conéctese a su instancia de SQL Server.
3. Cree una base de datos vacía llamada `Prueba_Caso`:

   ```sql
   CREATE DATABASE Prueba_Caso;
   GO
   ```

4. Abra el archivo `Prueba_Caso.sql` en SSMS y ejecútelo sobre esa instancia. El script crea las tablas y los procedimientos almacenados de la aplicación.
5. Si utiliza otro nombre de base de datos, ajuste la instrucción `USE [Prueba_Caso]` al inicio del script y la cadena de conexión.

> **Nota:** el script contiene la definición de 17 tablas y 36 procedimientos almacenados. No incluye registros de prueba precargados; si necesita datos para probar los módulos, deberá ingresarlos desde la aplicación o agregar datos de demostración en SQL Server.

## Configurar la conexión

La cadena de conexión de ejemplo está en `SistemaCableInternet/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=Prueba_Caso;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

Cambie `Server=localhost` por el nombre de su instancia de SQL Server. La configuración usa autenticación de Windows. Si utiliza autenticación de SQL Server, configure su propia cadena de conexión local y no publique credenciales en el repositorio.

También puede sobrescribir la cadena mediante la variable de entorno `ConnectionStrings__DefaultConnection`.

## Ejecutar la aplicación

### Desde Visual Studio 2022

1. Abra `SistemaCableInternet/SistemaCableInternet.sln`.
2. Verifique la cadena de conexión y que SQL Server esté iniciado.
3. Establezca `SistemaCableInternet` como proyecto de inicio.
4. Ejecute con **F5** o **Ctrl + F5**.

### Desde la terminal

Desde la carpeta que contiene el repositorio:

```bash
dotnet restore SistemaCableInternet/SistemaCableInternet.sln
dotnet run --project SistemaCableInternet/SistemaCableInternet.csproj
```

Use la URL local que indique la consola o el perfil de ejecución de Visual Studio.

## Módulos incluidos

- Clientes
- Servicios
- Planes
- Contratos
- Direcciones
- Zonas
- Asignación de servicios a contratos y tarifas

## Notas

- La solución contiene tres proyectos: `SistemaCableInternet` (presentación), `SistemaCableInternet.BLL` (lógica de negocio) y `SistemaCableInternet.DAL` (acceso a datos).
- Los directorios generados por Visual Studio y .NET (`bin`, `obj`, `.vs`) se excluyen del control de versiones.
- Los reportes de Power BI no se incluyen en este paquete porque no venían dentro del ZIP recibido.
