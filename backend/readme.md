# API Clientes - SONDA

Taller para el desarrollo simple de una API en .NET Core 2 con Entity Framework.

**Herramientas necesarias:**
 - Visual Studio 2017 (Con .NET Core 2)
 - NET Core 2.1 SDK
 - Postman
 - SQL Server (opcional)
 ---

|Verbo|URI|Descripción|
|--|--|--|
|*GET*|cliente|Obtiene todos los clientes que están registrados en el sistema|
|*GET*|cliente/:rut|Obtiene los datos del cliente especificando el RUT|
|*POST*|cliente|Ingresar un nuevo cliente|
|*DELETE*|cliente/:rut|Elimina un cliente especificando el RUT|


## Fuentes

> **.NET Core**: https://docs.microsoft.com/en-us/dotnet/core/

> **EF Core**: https://docs.microsoft.com/es-es/ef/core/

> **Mejores Practicas API Microsoft** : https://docs.microsoft.com/en-us/azure/architecture/best-practices/api-design

> **API Guidelines Microsoft** : https://github.com/Microsoft/api-guidelines/blob/vNext/Guidelines.md

> **Swagger .NET Core**: https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-2.1
