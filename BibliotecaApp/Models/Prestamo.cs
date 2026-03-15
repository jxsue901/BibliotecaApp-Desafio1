using System;

namespace BibliotecaApp.Models
{
    public enum EstadoPrestamo
    {
        Activo,
        Devuelto,
        Vencido
    }

    public class Prestamo
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int LibroId { get; set; }
        public string NombreUsuario { get; set; }
        public string TituloLibro { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public DateTime? FechaDevuelto { get; set; }
        public EstadoPrestamo Estado { get; set; }

        public Prestamo() { }

        public Prestamo(int id, int usuarioId, int libroId, string nombreUsuario, string tituloLibro, DateTime fechaPrestamo, DateTime fechaDevolucion)
        {
            Id = id;
            UsuarioId = usuarioId;
            LibroId = libroId;
            NombreUsuario = nombreUsuario;
            TituloLibro = tituloLibro;
            FechaPrestamo = fechaPrestamo;
            FechaDevolucion = fechaDevolucion;
            FechaDevuelto = null;
            Estado = EstadoPrestamo.Activo;
        }

        public string EstadoTexto => Estado.ToString();
    }
}
