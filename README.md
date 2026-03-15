# 📚 Sistema de Gestión de Biblioteca

> Aplicación de escritorio desarrollada en **C# con Windows Forms (.NET Framework 4.7.2)** para la gestión integral de una biblioteca. Permite administrar libros, usuarios y préstamos mediante un CRUD completo con interfaz gráfica moderna.

---

## 📋 Tabla de Contenidos

1. [Requisitos del Sistema](#requisitos-del-sistema)
2. [Instalación](#instalación)
3. [Guía de Uso](#guía-de-uso)
4. [Guía de Despliegue](#guía-de-despliegue)
5. [Estructura del Proyecto](#estructura-del-proyecto)
6. [Principios Técnicos Aplicados](#principios-técnicos-aplicados)

---

## ✅ Requisitos del Sistema

| Componente | Versión mínima |
|---|---|
| Sistema Operativo | Windows 10 / Windows 11 |
| Visual Studio | 2019 (versión 16.x o superior) |
| .NET Framework | 4.7.2 |
| RAM | 512 MB disponibles |
| Espacio en disco | 50 MB |

> No requiere instalación de base de datos ni dependencias externas.

---

## 🔧 Instalación

### Paso 1 — Obtener el código fuente

**Opción A — Clonar el repositorio:**
```bash
git clone <URL_DEL_REPOSITORIO>
cd BibliotecaApp
```

**Opción B — Descargar ZIP:**
1. Descargar y descomprimir el archivo `BibliotecaApp.zip`
2. Extraer en una carpeta de fácil acceso (ej. `C:\Proyectos\BibliotecaApp`)

### Paso 2 — Abrir en Visual Studio 2019

1. Abrir **Visual Studio 2019**
2. Ir a **Archivo → Abrir → Proyecto/Solución...**
3. Navegar hasta la carpeta del proyecto
4. Seleccionar el archivo `BibliotecaApp.sln` y clic en **Abrir**

### Paso 3 — Compilar y ejecutar

- **Compilar:** `Ctrl + Shift + B`
- **Ejecutar:** `F5` (con depuración) o `Ctrl + F5` (sin depuración)

La aplicación se abre con datos de ejemplo precargados.

---

## 📖 Guía de Uso

### Pantalla Principal

La ventana principal tiene **4 pestañas**:
```
[ 📚 Libros ]  [ 👤 Usuarios ]  [ 📋 Préstamos ]  [ 📊 Estadísticas ]
```

### 📚 Libros

| Acción | Pasos |
|---|---|
| **Ver** | Tabla con ID, Título, Autor, Año, ISBN, Disponibles |
| **Buscar** | Escribir en 🔍 Buscar — filtra en tiempo real |
| **Agregar** | Clic en **+ Añadir** → completar datos → **Guardar** |
| **Editar** | Seleccionar fila → **✏ Editar** → modificar → **Guardar** |
| **Eliminar** | Seleccionar fila → **🗑 Eliminar** → confirmar |

> No se puede eliminar un libro con préstamos activos.

### 👤 Usuarios

| Acción | Pasos |
|---|---|
| **Agregar** | Clic en **+ Añadir** → Nombre, Apellido, Correo, Teléfono → **Guardar** |
| **Editar** | Seleccionar → **✏ Editar** → modificar → **Guardar** |
| **Eliminar** | Seleccionar → **🗑 Eliminar** → confirmar |

> No se puede eliminar un usuario con préstamos activos.

### 📋 Préstamos

| Acción | Pasos |
|---|---|
| **Nuevo préstamo** | Clic en **+ Nuevo** → seleccionar usuario y libro → fechas → **Registrar** |
| **Devolver** | Seleccionar préstamo activo → **↩ Devolver** → confirmar |
| **Eliminar** | Solo préstamos devueltos → **🗑 Eliminar** → confirmar |

**Estados:**
- `Activo` — libro prestado y en plazo
- `Vencido` — fecha de devolución superada
- `Devuelto` — devuelto correctamente

### 📊 Estadísticas

- Tarjetas: Total Libros, Total Usuarios, Total Préstamos, Activos
- Gráfico de barras: Libros más prestados (top 5)
- Gráfico de barras: Usuarios más activos (top 5)

---

## 🚀 Guía de Despliegue

### Opción 1 — Desarrollo (desde Visual Studio)

```
Configuración: Debug | Any CPU → F5
```

### Opción 2 — Producción (ejecutable Release)

1. Cambiar configuración a **Release** en la barra de Visual Studio
2. **Compilar → Compilar solución** (`Ctrl + Shift + B`)
3. El ejecutable queda en:
   ```
   BibliotecaApp\BibliotecaApp\bin\Release\BibliotecaApp.exe
   ```
4. Para distribuir, copiar toda la carpeta `Release\` al equipo destino.

### Opción 3 — Instalador MSI

1. Instalar extensión: **Microsoft Visual Studio Installer Projects**
   (Extensiones → Administrar extensiones → buscar "Installer Projects")
2. Agregar nuevo proyecto tipo **Setup Project** a la solución
3. Arrastrar el output de `BibliotecaApp` al instalador
4. Compilar → genera `Setup.msi` listo para distribuir

### Requisitos en el equipo de destino

- Windows 10 o superior
- .NET Framework 4.7.2 (incluido por defecto en Windows 10 actualizado)

**Verificar .NET instalado:**
```
Ejecutar (Win+R): reg query "HKLM\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full" /v Release
```
Si el valor `Release >= 461808`, .NET 4.7.2 está instalado.

---

## 📁 Estructura del Proyecto

```
BibliotecaApp/
├── BibliotecaApp.sln              # Solución (abrir con VS 2019)
├── README.md                       # Documentación
├── .gitignore
└── BibliotecaApp/
    ├── BibliotecaApp.csproj        # Configuración del proyecto
    ├── Program.cs                  # Punto de entrada (Main)
    ├── Models/
    │   ├── Libro.cs                # Clase Libro
    │   ├── Usuario.cs              # Clase Usuario
    │   └── Prestamo.cs             # Clase Prestamo + Enum Estado
    ├── Data/
    │   └── BibliotecaDB.cs         # Capa de datos en memoria (Singleton)
    └── Forms/
        ├── FormPrincipal.cs/.Designer.cs
        ├── FormLibro.cs/.Designer.cs
        ├── FormUsuario.cs/.Designer.cs
        └── FormPrestamo.cs/.Designer.cs
```

---

## 🛠️ Principios Técnicos Aplicados

### POO

| Principio | Implementación |
|---|---|
| **Clases** | `Libro`, `Usuario`, `Prestamo`, `BibliotecaDB`, 4 formularios |
| **Encapsulamiento** | Propiedades `get/set`, campos privados `_campo` |
| **Herencia** | Todos los formularios heredan de `Form` |
| **Polimorfismo** | `ToString()` sobreescrito en `Libro` y `Usuario` |

### Estructuras de Datos

| Tipo | Uso |
|---|---|
| `List<T>` | Almacenamiento de libros, usuarios, préstamos |
| `Dictionary<int,T>` | Búsqueda rápida por ID (O(1)) |
| `int[]` *(matriz)* | Resumen estadístico con 5 indicadores |

### Funciones propias destacadas

- `CargarLibros()` / `CargarUsuarios()` / `CargarPrestamos()` — poblar grillas
- `DibujarGraficoLibros()` / `DibujarGraficoUsuarios()` — gráficos con GDI+
- `ActualizarResumen()` — actualiza tarjetas de estadísticas
- `ConfigurarDataGridView()` / `ConfigurarBoton()` — reutilización de UI
- `ObtenerLibrosMasPrestados()` / `ObtenerUsuariosMasActivos()` — estadísticas

---

*Desafío 1 — Aplicación de Escritorio: Gestión de Biblioteca*
