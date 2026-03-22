using System;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Contacto { get; set; }
    public bool Activo { get; set; }

    public Usuario()
    {
        Activo = true;
    }

    public Usuario(int id, string nombre, string contacto)
    {
        Id = id;
        Nombre = nombre;
        Contacto = contacto;
        Activo = true;
    }

    public string ResumenCorto()
    {
        return $"{Nombre}";
    }

    public string DetalleCompleto()
    {
        return $"ID: {Id}, Nombre: {Nombre}, Contacto: {Contacto}, Activo: {Activo}";
    }

    public override string ToString()
    {
        return DetalleCompleto();
    }
}