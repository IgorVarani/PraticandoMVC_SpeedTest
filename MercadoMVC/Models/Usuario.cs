using System;
using System.Collections.Generic;

namespace MVC_Mercado.Models;

public partial class Usuario
{
    public int UsuarioID { get; set; }

    public string NomeUsuario { get; set; } = null!;

    public string Email { get; set; } = null!;

    public byte[] Senha { get; set; } = null!;

    public virtual ICollection<Inter_ItemUsuario> Inter_ItemUsuario { get; set; } = new List<Inter_ItemUsuario>();
}
