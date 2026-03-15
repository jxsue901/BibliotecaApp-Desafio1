using System;

namespace BibliotecaApp.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaRegistro { get; set; }

        public Usuario() { }

        public Usuario(int id, string nombre, string apellido, string correo, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            Telefono = telefono;
            FechaRegistro = DateTime.Now;
        }

        public string NombreCompleto => $"{Nombre} {Apellido}";

        public override string ToString()
        {
            return NombreCompleto;
        }
    }
}
