using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaApp.Models;

namespace BibliotecaApp.Data
{
    /// <summary>
    /// Capa de datos que usa listas, diccionarios y matrices (estructuras de datos).
    /// Simula una base de datos en memoria.
    /// </summary>
    public class BibliotecaDB
    {
        // Estructuras de datos principales
        private List<Libro> _libros;
        private List<Usuario> _usuarios;
        private List<Prestamo> _prestamos;

        // Diccionarios para acceso rápido por ID
        private Dictionary<int, Libro> _librosDict;
        private Dictionary<int, Usuario> _usuariosDict;

        // Contadores de ID
        private int _libroIdCounter = 1;
        private int _usuarioIdCounter = 1;
        private int _prestamoIdCounter = 1;

        // Singleton
        private static BibliotecaDB _instancia;
        public static BibliotecaDB Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new BibliotecaDB();
                return _instancia;
            }
        }

        private BibliotecaDB()
        {
            _libros = new List<Libro>();
            _usuarios = new List<Usuario>();
            _prestamos = new List<Prestamo>();
            _librosDict = new Dictionary<int, Libro>();
            _usuariosDict = new Dictionary<int, Usuario>();
            CargarDatosEjemplo();
        }

        private void CargarDatosEjemplo()
        {
            // Libros de ejemplo
            AgregarLibro("El Gran Gatsby", "F. Scott Fitzgerald", 1925, "978-0-7432-7356-5", 5);
            AgregarLibro("Matar a un Ruiseñor", "Harper Lee", 1960, "978-0-06-112008-4", 3);
            AgregarLibro("1984", "George Orwell", 1949, "978-0-452-28423-4", 4);
            AgregarLibro("Orgullo y Prejuicio", "Jane Austen", 1813, "978-0-14-143951-8", 2);
            AgregarLibro("Cien Años de Soledad", "Gabriel García Márquez", 1967, "978-0-06-088328-7", 3);

            // Usuarios de ejemplo
            AgregarUsuario("Juan", "Pérez", "juan.perez@email.com", "7777-1111");
            AgregarUsuario("María", "Gómez", "maria.gomez@email.com", "7777-2222");
            AgregarUsuario("Ana", "Torres", "ana.torres@email.com", "7777-3333");

            // Préstamos de ejemplo
            AgregarPrestamo(1, 1, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(4));
            AgregarPrestamo(2, 3, DateTime.Now.AddDays(-5), DateTime.Now.AddDays(9));
        }

        // ===================== LIBROS =====================

        public List<Libro> ObtenerLibros() => new List<Libro>(_libros);

        public Libro ObtenerLibroPorId(int id)
        {
            _librosDict.TryGetValue(id, out Libro libro);
            return libro;
        }

        public bool AgregarLibro(string titulo, string autor, int anio, string isbn, int cantidad)
        {
            if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(autor))
                throw new ArgumentException("El título y el autor son obligatorios.");

            if (_libros.Any(l => l.ISBN == isbn && !string.IsNullOrWhiteSpace(isbn)))
                throw new Exception("Ya existe un libro con ese ISBN.");

            var libro = new Libro(_libroIdCounter++, titulo, autor, anio, isbn, cantidad);
            _libros.Add(libro);
            _librosDict[libro.Id] = libro;
            return true;
        }

        public bool ActualizarLibro(int id, string titulo, string autor, int anio, string isbn, int cantidad)
        {
            var libro = ObtenerLibroPorId(id);
            if (libro == null) throw new Exception("Libro no encontrado.");

            int prestadosActuales = libro.CantidadTotal - libro.CantidadDisponible;
            if (cantidad < prestadosActuales)
                throw new Exception($"No se puede reducir la cantidad. Hay {prestadosActuales} libro(s) prestado(s) actualmente.");

            libro.Titulo = titulo;
            libro.Autor = autor;
            libro.Anio = anio;
            libro.ISBN = isbn;
            libro.CantidadDisponible = cantidad - prestadosActuales;
            libro.CantidadTotal = cantidad;
            return true;
        }

        public bool EliminarLibro(int id)
        {
            var libro = ObtenerLibroPorId(id);
            if (libro == null) throw new Exception("Libro no encontrado.");

            bool tienePrestamosActivos = _prestamos.Any(p => p.LibroId == id && p.Estado == EstadoPrestamo.Activo);
            if (tienePrestamosActivos)
                throw new Exception("No se puede eliminar el libro porque tiene préstamos activos.");

            _libros.Remove(libro);
            _librosDict.Remove(id);
            return true;
        }

        // ===================== USUARIOS =====================

        public List<Usuario> ObtenerUsuarios() => new List<Usuario>(_usuarios);

        public Usuario ObtenerUsuarioPorId(int id)
        {
            _usuariosDict.TryGetValue(id, out Usuario usuario);
            return usuario;
        }

        public bool AgregarUsuario(string nombre, string apellido, string correo, string telefono)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El nombre y apellido son obligatorios.");

            if (_usuarios.Any(u => u.Correo.Equals(correo, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Ya existe un usuario con ese correo electrónico.");

            var usuario = new Usuario(_usuarioIdCounter++, nombre, apellido, correo, telefono);
            _usuarios.Add(usuario);
            _usuariosDict[usuario.Id] = usuario;
            return true;
        }

        public bool ActualizarUsuario(int id, string nombre, string apellido, string correo, string telefono)
        {
            var usuario = ObtenerUsuarioPorId(id);
            if (usuario == null) throw new Exception("Usuario no encontrado.");

            bool correoRepetido = _usuarios.Any(u => u.Id != id &&
                u.Correo.Equals(correo, StringComparison.OrdinalIgnoreCase));
            if (correoRepetido)
                throw new Exception("Ya existe otro usuario con ese correo electrónico.");

            usuario.Nombre = nombre;
            usuario.Apellido = apellido;
            usuario.Correo = correo;
            usuario.Telefono = telefono;
            return true;
        }

        public bool EliminarUsuario(int id)
        {
            var usuario = ObtenerUsuarioPorId(id);
            if (usuario == null) throw new Exception("Usuario no encontrado.");

            bool tienePrestamosActivos = _prestamos.Any(p => p.UsuarioId == id && p.Estado == EstadoPrestamo.Activo);
            if (tienePrestamosActivos)
                throw new Exception("No se puede eliminar el usuario porque tiene préstamos activos.");

            _usuarios.Remove(usuario);
            _usuariosDict.Remove(id);
            return true;
        }

        // ===================== PRÉSTAMOS =====================

        public List<Prestamo> ObtenerPrestamos() => new List<Prestamo>(_prestamos);

        public List<Prestamo> ObtenerPrestamosPorUsuario(int usuarioId)
            => _prestamos.Where(p => p.UsuarioId == usuarioId).ToList();

        public bool AgregarPrestamo(int usuarioId, int libroId, DateTime fechaPrestamo, DateTime fechaDevolucion)
        {
            var usuario = ObtenerUsuarioPorId(usuarioId);
            if (usuario == null) throw new Exception("Usuario no encontrado.");

            var libro = ObtenerLibroPorId(libroId);
            if (libro == null) throw new Exception("Libro no encontrado.");

            if (libro.CantidadDisponible <= 0)
                throw new Exception("No hay ejemplares disponibles de este libro.");

            if (fechaDevolucion <= fechaPrestamo)
                throw new Exception("La fecha de devolución debe ser posterior a la fecha de préstamo.");

            bool yaLoTiene = _prestamos.Any(p => p.UsuarioId == usuarioId &&
                p.LibroId == libroId && p.Estado == EstadoPrestamo.Activo);
            if (yaLoTiene)
                throw new Exception("El usuario ya tiene prestado este libro.");

            var prestamo = new Prestamo(_prestamoIdCounter++, usuarioId, libroId,
                usuario.NombreCompleto, libro.Titulo, fechaPrestamo, fechaDevolucion);
            _prestamos.Add(prestamo);
            libro.CantidadDisponible--;
            return true;
        }

        public bool RegistrarDevolucion(int prestamoId)
        {
            var prestamo = _prestamos.FirstOrDefault(p => p.Id == prestamoId);
            if (prestamo == null) throw new Exception("Préstamo no encontrado.");
            if (prestamo.Estado == EstadoPrestamo.Devuelto)
                throw new Exception("Este préstamo ya fue devuelto.");

            prestamo.Estado = EstadoPrestamo.Devuelto;
            prestamo.FechaDevuelto = DateTime.Now;

            var libro = ObtenerLibroPorId(prestamo.LibroId);
            if (libro != null) libro.CantidadDisponible++;
            return true;
        }

        public bool EliminarPrestamo(int prestamoId)
        {
            var prestamo = _prestamos.FirstOrDefault(p => p.Id == prestamoId);
            if (prestamo == null) throw new Exception("Préstamo no encontrado.");
            if (prestamo.Estado == EstadoPrestamo.Activo)
                throw new Exception("No se puede eliminar un préstamo activo. Primero registre la devolución.");

            _prestamos.Remove(prestamo);
            return true;
        }

        // ===================== ESTADÍSTICAS =====================

        public Dictionary<string, int> ObtenerLibrosMasPrestados(int top = 5)
        {
            return _prestamos
                .GroupBy(p => p.TituloLibro)
                .ToDictionary(g => g.Key, g => g.Count())
                .OrderByDescending(kv => kv.Value)
                .Take(top)
                .ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        public Dictionary<string, int> ObtenerUsuariosMasActivos(int top = 5)
        {
            return _prestamos
                .GroupBy(p => p.NombreUsuario)
                .ToDictionary(g => g.Key, g => g.Count())
                .OrderByDescending(kv => kv.Value)
                .Take(top)
                .ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        public int[] ObtenerResumenEstadistico()
        {
            // Matriz: [totalLibros, totalUsuarios, totalPrestamos, prestamosActivos, prestamosVencidos]
            int[] resumen = new int[5];
            resumen[0] = _libros.Count;
            resumen[1] = _usuarios.Count;
            resumen[2] = _prestamos.Count;
            resumen[3] = _prestamos.Count(p => p.Estado == EstadoPrestamo.Activo);
            resumen[4] = _prestamos.Count(p => p.Estado == EstadoPrestamo.Vencido ||
                (p.Estado == EstadoPrestamo.Activo && p.FechaDevolucion < DateTime.Now));
            return resumen;
        }
    }
}
