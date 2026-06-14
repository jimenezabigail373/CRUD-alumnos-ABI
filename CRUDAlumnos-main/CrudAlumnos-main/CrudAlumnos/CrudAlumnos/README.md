# CRUD Alumnos — ASP.NET Core MVC + Entity Framework Core

Aplicación web para gestión de alumnos desarrollada con ASP.NET Core 6 MVC y Entity Framework Core.

## Tecnologías

- ASP.NET Core 6 MVC
- Entity Framework Core 6 (SQL Server)
- Bootstrap 5 + Bootstrap Icons
- SQL Server

## Estructura del Proyecto

```
CrudAlumnos/
├── Controllers/
│   └── AlumnosController.cs      ← CRUD completo + vista parcial ciudades
├── Data/
│   └── AppDbContext.cs           ← DbContext con Alumnos y Ciudades
├── Models/
│   ├── Alumno.cs                 ← Entidad Alumno con validaciones
│   └── Ciudad.cs                 ← Entidad Ciudad
├── Views/
│   ├── Alumnos/
│   │   ├── Index.cshtml          ← Lista de alumnos
│   │   ├── Create.cshtml         ← Formulario de registro
│   │   ├── Edit.cshtml           ← Formulario de edición
│   │   ├── Details.cshtml        ← Detalle del alumno
│   │   └── Delete.cshtml         ← Confirmación de eliminación
│   └── Shared/
│       ├── _Layout.cshtml        ← Layout principal
│       └── _ListaCiudades.cshtml ← Vista parcial de ciudades
├── wwwroot/css/site.css
├── appsettings.json              ← Cadena de conexión
├── Program.cs                    ← Configuración de la app
├── Scripts_BD.sql                ← Script de base de datos
└── README.md
```

## Configuración y Ejecución

### 1. Base de Datos

Ejecutar el script `Scripts_BD.sql` en SQL Server Management Studio:

```sql
-- El script crea la base de datos, tablas y datos de prueba automáticamente
```

También crea un usuario `alumno` con contraseña `ABcd1234`. Si prefieres usar otro usuario, ajusta el paso 2.

### 2. Cadena de Conexión

Editar `appsettings.json` con tu configuración de SQL Server:

```json
"DefaultConnection": "Server=TU_SERVIDOR;Database=CrudAlumnos;User Id=alumno;Password=ABcd1234;TrustServerCertificate=True;"
```

Para autenticación de Windows usa:
```json
"DefaultConnection": "Server=localhost;Database=CrudAlumnos;Trusted_Connection=True;TrustServerCertificate=True;"
```

### 3. Restaurar paquetes y ejecutar

```bash
dotnet restore
dotnet run
```

Navegar a `https://localhost:5001` o `http://localhost:5000`.

## Funcionalidades

| Operación | Ruta               | Descripción                        |
|-----------|--------------------|------------------------------------|
| Listar    | `/Alumnos`         | Tabla con todos los alumnos        |
| Crear     | `/Alumnos/Create`  | Formulario de nuevo alumno         |
| Editar    | `/Alumnos/Edit/id` | Formulario de edición              |
| Detalle   | `/Alumnos/Details/id` | Vista de detalle                |
| Eliminar  | `/Alumnos/Delete/id` | Confirmación antes de eliminar   |

## Notas

- Las validaciones están implementadas con DataAnnotations en el modelo.
- El dropdown de ciudades se carga desde la base de datos.
- Se incluye vista parcial `_ListaCiudades` como referencia del curso.
