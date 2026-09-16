using System;
using System.Collections.Generic;

namespace BibliotecaMVC.Models;

public partial class Usuario
{
    public int UsuarioID { get; set; }

    public string NomeUsuario { get; set; } = null!;

    public string Email { get; set; } = null!;

    public byte[] Senha { get; set; } = null!;

    public virtual ICollection<Inter_LivroUsuario> Inter_LivroUsuarios { get; set; } = new List<Inter_LivroUsuario>();
}
