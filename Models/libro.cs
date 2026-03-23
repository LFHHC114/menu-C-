using System;

public class Libro
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;

    public string Autor { get; set; }= string.Empty;

    public int Año { get; set; }
    public string Categoria { get; set; }= string.Empty;

    public bool Disponible { get; set; }

    public Libro()
    {
        Disponible = true;
    }

    public Libro(int id, string titulo, string autor, int anio, string categoria)
    {
        Id = id;
        Titulo = titulo;
        Autor = autor;
        Año = anio;
        Categoria = categoria;
        Disponible = true;
    }

    public string ResumenCorto()
    {
        return $"{Titulo} - {Autor}";
    }

    public string DetalleCompleto()
    {
        return $"ID: {Id}, Título: {Titulo}, Autor: {Autor}, Año: {Anio}, Categoría: {Categoria}, Disponible: {Disponible}";
    }

    public override string ToString()
    {
        return DetalleCompleto();
    }
}