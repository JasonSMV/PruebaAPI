

## Descripción

Este proyecto es una aplicación Web API desarrollada con .NET Core 8 y utiliza SQLite como motor de base de datos, el cual se genera automáticamente al ejecutar el proyecto. 

## Requisitos

- .NET Core SDK 8.0 o superior
- Visual Studio 2022 o superior

## Instalación

1. Clonar el repositorio:

2. Restaurar las dependencias y construir el proyecto:

   ```sh
   dotnet restore
   dotnet build
   ```

## Ejecución

1. Ejecutar la aplicación:

   ```sh
   dotnet run
   ```

2. Una vez que el proyecto esté en ejecución, puede ir a Swagger y probar los endpoints directamente desde ahí o con el endpoint https://localhost:7023/api/Reporte:

   [Swagger UI](https://localhost:7023/swagger/index.html) https://localhost:7023/swagger/index.html

## Endpoints Disponibles

### ContieneNombre

#### POST /api/ContieneNombre

Valida si un nombre está contenido en una matriz de caracteres.

```json
{
  "info": ["ATFVRA", "B4KHES", "5JENTY", "T6IRF3", "ELLJ54", "24JKRT"],
  "nombre": "LINEA"
}
```

#### Ejemplo de Respuesta

```json
{
  "resultado": true
}
```

### Reporte

#### GET /api/Reporte

Obtiene las estadísticas de validación de nombres.

#### Ejemplo de Respuesta

```json
{
  "CuentaContieneNombre": 5,
  "CuentaNoContieneNombre": 3,
  "Relacion": 0.625
}
```

---
