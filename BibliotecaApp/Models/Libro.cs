using System;

namespace BibliotecaApp.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Anio { get; set; }
        public string ISBN { get; set; }
        public int CantidadTotal { get; set; }
        public int CantidadDisponible { get; set; }

        public Libro() { }

        public Libro(int id, string titulo, string autor, int anio, string isbn, int cantidad)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Anio = anio;
            ISBN = isbn;
            CantidadTotal = cantidad;
            CantidadDisponible = cantidad;
        }

        public override string ToString()
        {
            return $"{Titulo} - {Autor} ({Anio})";
        }
    }
}
