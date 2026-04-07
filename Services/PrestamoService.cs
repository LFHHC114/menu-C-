using System;
using System.Collections.Generic;
using System.Linq;

public class PrestamoService
{
    private List<Prestamo> prestamos = new List<Prestamo>();


    public void AgregarPrestamo(Prestamo prestamo)
    {
        prestamos.Add(prestamo);
    }

    public List<Prestamo> ObtenerTodos()
    {
        return prestamos;
    }

    public List<Prestamo> BuscarPorEstado(EstadoPrestamo estado)
    {
        return prestamos.Where(p => p.Estado == estado).ToList();
    }

    public List<Prestamo> OrdenarPorFecha()
    {
        return prestamos.OrderBy(p => p.FechaPrestamo).ToList();
    }

   
    public int TotalPrestamos()
    {
        return prestamos.Count;
    }

    public int PrestamosActivos()
    {
        return prestamos.Count(p => p.Estado == EstadoPrestamo.Activo);
    }

    
    public int PrestamosVencidos()
    {
        return prestamos.Count(p => p.EstaVencido());
    }

    public int PrestamosDevueltos()
    {
        return prestamos.Count(p => p.Estado == EstadoPrestamo.Devuelto);
    }

    public double PromedioDiasPrestamo()
    {
        if (prestamos.Count == 0)
            return 0;

        return prestamos.Average(p => p.DiasTranscurridos());
    }
}