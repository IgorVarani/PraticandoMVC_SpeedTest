using System;
using System.Collections.Generic;

namespace BibliotecaMVC.Models;

public partial class Inter_LivroUsuario
{
    public int Inter_LivroUsuarioID { get; set; }

    public int LivroID { get; set; }

    public int UsuarioID { get; set; }

    public virtual Livro Livro { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
