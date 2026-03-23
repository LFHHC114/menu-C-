using System;

public class Libro
{
    public int Id { get; set; }
    public string Titulo { get; set; }

    public string Autor { get; set; }

    public int Año { get; set; }
    public string Categoria { get; set; }

    public bool Disponible { get; set; }

    public Libro()
    {
        Disponible = true;
    }

    public Libro(int id, string titulo, string autor, int año, string categoria)
    {
        Id = id;
        Titulo = titulo;
        Autor = autor;
        Año = año;
        Categoria = categoria;
        Disponible = true;
    }

    public string ResumenCorto()
    {
        return $"{Titulo} - {Autor}";
    }

    public string DetalleCompleto()
    {
        return $"ID: {Id}, Título: {Titulo}, Autor: {Autor}, Año: {Año}, Categoría: {Categoria}, Disponible: {Disponible}";
    }

    public override string ToString()
    {
        return DetalleCompleto();
    }
}