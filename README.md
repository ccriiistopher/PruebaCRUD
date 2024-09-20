# Información
Este proyecto fue desarrollado en Visual Studio siguiendo el patrón MVC, demuestra el funcionamiento de un CRUD dotnet core WEB vinculado a una base de datos en SQL Server.

# Requerimientos
- Microsoft Visual Studio Community 2022
- SQL Server 2022

# Iniciando
- Crear base de datos con el nombre wayni-prueba
- Dirigirse a la solución 'PruebaCRUD', editar el archivo 'appsettings.json', ubicar la sección
  ```
        "ConnectionStrings": {
            "DefaultConnection": ""
        }
    ```
    Reemplazar el valor de DeffaultConnection por la cadena de conexión con la base de datos
- Abrir la Consola del Admnistrador de Paquetes y ejecutar los siguientes comando para iniciar la base de datos
  ```
    PM> Add-Migration InitialCreate
    PM> Update-Database
  ```
- Por último, abrir la consola de PowerShell para programadores, verificar que la ruta está en el proyecto PruebaCRUD dentro de la solución con el mismo nombre `\PruebaCRUD\PruebaCRUD>` y ejecutar lo siguiente:
  ```
    dotnet run seeddata
  ```
  - Ejecutar el proyecto
  
