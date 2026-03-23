using System;

public class Prestamo
{
    public int Id { get; set; }
    public Libro Libro { get; set; }
    public Usuario Usuario { get; set; }
    public DateTime FechaPrestamo { get; set; }
    public DateTime? FechaDevolucion { get; set; }
    public EstadoPrestamo Estado { get; set; }

    public Prestamo()
    {
        Estado = EstadoPrestamo.Activo;
        FechaDevolucion = null;
    }

    public Prestamo(int id, Libro libro, Usuario usuario, DateTime fechaPrestamo)
    {
        Id = id;
        Libro = libro;
        Usuario = usuario;
        FechaPrestamo = fechaPrestamo;
        Estado = EstadoPrestamo.Activo;
        FechaDevolucion = null;
    }

    public bool EstaVencido()
    {
        return (DateTime.Now - FechaPrestamo).Days > 7 && Estado == EstadoPrestamo.Activo;
    }

    public int DiasTranscurridos()
    {
        return (DateTime.Now - FechaPrestamo).Days;
    }

    public string ResumenCorto()
    {
        return $"Préstamo {Id} - {Libro.Titulo} a {Usuario.Nombre}";
    }

    public string DetalleCompleto()
    {
        return $"ID: {Id}, Libro: {Libro.Titulo}, Usuario: {Usuario.Nombre}, Estado: {Estado}, Días: {DiasTranscurridos()}";
    }

    public override string ToString()
    {
        return DetalleCompleto();
    }
}