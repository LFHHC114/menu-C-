using System;
using System.Collections.Generic;
using System.Linq;

public class LibroService
{
    private List<Libro> libros = new List<Libro>();

    public void AgregarLibro(Libro libro)
    {
        libros.Add(libro);
    }

    public List<Libro> ObtenerTodos()
    {
        return libros;
    }

    public Libro BuscarPorTitulo(string titulo)
    {
        return libros.FirstOrDefault(l => l.Titulo.ToLower() == titulo.ToLower());
    }

    public List<Libro> OrdenarPorTitulo()
    {
        return libros.OrderBy(l => l.Titulo).ToList();
    }

    // KPIs
    public int TotalLibros() => libros.Count;

    public int LibrosDisponibles() => libros.Count(l => l.Disponible);

    public int LibrosPrestados() => libros.Count(l => !l.Disponible);
}