using System;
using System.Collections.Generic;
using System.Linq;

public class UsuarioService
{
    private List<Usuario> usuarios = new List<Usuario>();

    public void AgregarUsuario(Usuario usuario)
    {
        usuarios.Add(usuario);
    }

    public List<Usuario> ObtenerTodos()
    {
        return usuarios;
    }

    public Usuario BuscarPorNombre(string nombre)
    {
        return usuarios.FirstOrDefault(u => u.Nombre.ToLower() == nombre.ToLower());
    }

    public List<Usuario> OrdenarPorNombre()
    {
        return usuarios.OrderBy(u => u.Nombre).ToList();
    }

    // KPIs
    public int TotalUsuarios() => usuarios.Count;

    public int UsuariosActivos() => usuarios.Count(u => u.Activo);

    public int UsuariosInactivos() => usuarios.Count(u => !u.Activo);
}